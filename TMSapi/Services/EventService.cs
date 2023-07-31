using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Serices
{
    public class EventService : IEventService
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;


        public EventService(IEventRepository eventRepository,IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;

        }


        public async Task<int> Add(EventDtoAdd eventDtoAdd)
        {

            var @event =_mapper.Map<Event>(eventDtoAdd);
            _eventRepository.Add(@event);
            return @event.EventId;

            
        }

        public async Task Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);

            if (eventEntity != null)
            {
                _eventRepository.Delete(eventEntity);
            }
            else
            {
                throw new InvalidOperationException($"Item with ID {id} not found in the database.");
            }
        }

        public async Task<IEnumerable<EventDto>> GetAll()
        {
            var events = await _eventRepository.GetAll();

            var dtoEvents = _mapper.Map<IEnumerable<EventDto>>(events);

            return dtoEvents; 
        }

        public async Task<EventDto> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);

            if (@event == null)
            {
                throw new InvalidOperationException($"Item with ID {@event.EventId} not found in the database");

            }

            var eventDto = _mapper.Map<EventDto>(@event);
            return eventDto;
        }

        public async Task<Event> Update(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if (eventEntity == null)
            {
                throw new InvalidOperationException($"Item with ID {eventPatch.EventId} not found in the database");
            }
            _mapper.Map(eventPatch, eventEntity);
            await _eventRepository.Update(eventEntity);

            return eventEntity;
           
        }
    }
}

