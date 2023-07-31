using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Services
{
	public class EventTypeService : IEventTypeService
	{

        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IMapper _mapper;
        public EventTypeService(IEventTypeRepository eventTypeRepository, IMapper mapper)
		{
            _eventTypeRepository = eventTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(EventTypeDtoAdd eventTypeDtoAdd)
        {
            var @event = _mapper.Map<EventType>(eventTypeDtoAdd);
            _eventTypeRepository.Add(@event);
            return @event.EventTypeId;
        }

        public async Task Delete(int id)
        {
            var eventEntity = await _eventTypeRepository.GetById(id);

            if (eventEntity != null)
            {
                await _eventTypeRepository.Delete(eventEntity);
            }
            else
            {
                throw new InvalidOperationException($"Item with ID {id} not found in the database.");
            }
        }

        public async Task<IEnumerable<EventTypeDto>> GetAll()
        {
            var events = await _eventTypeRepository.GetAll();

            var dtoEventTypes = _mapper.Map<IEnumerable<EventTypeDto>>(events);

            return dtoEventTypes;
        }

        public async Task<EventTypeDto> GetById(int id)
        {
            var @event = await _eventTypeRepository.GetById(id);

            if (@event == null)
            {
                throw new InvalidOperationException($"Item with ID {@event.EventTypeId} not found in the database");

            }

            var eventTypeDto = _mapper.Map<EventTypeDto>(@event);
            return eventTypeDto;
        }

        public async Task<EventType> Update(EventTypePatchDto eventTypePatch)
        {
            var eventEntity = await _eventTypeRepository.GetById(eventTypePatch.EventTypeId);
            if (eventEntity == null)
            {
                throw new InvalidOperationException($"Item with ID {eventTypePatch.EventTypeId} not found in the database");
            }
            _mapper.Map(eventTypePatch, eventEntity);
            await _eventTypeRepository.Update(eventEntity);

            return eventEntity;
        }
    }
}

