using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMSapi.Models.Dto;
using TMSapi.Repositories;
using TMSapi.Models;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMSapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("Get All Events")]
        public async Task<ActionResult<List<EventDto>>> GetAll() {
            var events = await _eventRepository.GetAll();

            var dtoEvents = _mapper.Map<List<EventDto>>(@events);
            return Ok(events);

        }


        [HttpGet("Get Events By Id")]

        public async Task<ActionResult<EventDto>> GetById(int id) {
            
            var @event = await _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();

            }
           
            var eventDto = _mapper.Map<EventDto>(@event);
            return Ok(eventDto);
            
        }

        [HttpPatch("Update Events")]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if (eventEntity == null)
            {
                return NotFound();
            }
            if (!eventPatch.EventName.IsNullOrEmpty()) eventEntity.EventName = eventPatch.EventName;
            if (!eventPatch.EventDescription.IsNullOrEmpty()) eventEntity.EventDescription = eventPatch.EventDescription;
            _eventRepository.Update(eventEntity);
            return NoContent();
        }

        [HttpDelete("Delete Event")]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }


        [HttpPost("Add Event")]
        public async Task<ActionResult<EventDtoAdd>> Add(EventDtoAdd eventDtoAdd)
        {
          
            Event event1 = new Event();
            _mapper.Map(eventDtoAdd, event1);
            _eventRepository.Add(event1);

            return Ok(event1);
        }

     

        

    }

}



