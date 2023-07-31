using System;
using Microsoft.AspNetCore.Mvc;
using TMSapi.Models.Dto;
using TMSapi.Serices;
using TMSapi.Services;

namespace TMSapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventTypeController : ControllerBase
	{ 
        private readonly IEventTypeService _eventTypeService;
	
		public EventTypeController(IEventTypeService eventTypeService)
		{
			_eventTypeService = eventTypeService;
		}

        [HttpGet]
        public async Task<ActionResult<List<EventTypeDto>>> GetAll()
        {

            var dtoEvents = await _eventTypeService.GetAll();
            return Ok(dtoEvents);

        }

        [HttpGet]

        public async Task<ActionResult<EventTypeDto>> GetById(int id)
        {

            var dtoEvent = await _eventTypeService.GetById(id);
            return Ok(dtoEvent);

        }

        [HttpPatch]
        public async Task<ActionResult<EventTypePatchDto>> Patch(EventTypePatchDto eventTypePatchDto)
        {
            var eventTypeEntity = await _eventTypeService.Update(eventTypePatchDto);
            return Ok(eventTypeEntity);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventTypeService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EventTypeDtoAdd>> Add(EventTypeDtoAdd eventTypeDtoAdd)
        {
            var eventTypeId = await _eventTypeService.Add(eventTypeDtoAdd); 
            return Ok(eventTypeId);
        }


    }
}

