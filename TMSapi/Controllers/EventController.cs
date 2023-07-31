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


using TMSapi.Serices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMSapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
    
        private readonly ILogger _logger;
        private readonly IEventService _eventService;


        public EventController( ILogger<EventController> logger, IEventService eventService)
        {
          
            _logger = logger;
            _eventService = eventService;


        }
     
        [HttpGet("Get All Events")]
        public async Task<ActionResult<List<EventDto>>> GetAll() {

            var dtoEvents =await _eventService.GetAll();
            return Ok(dtoEvents);
      
        }


        [HttpGet("Get Events By Id")]

        public async Task<ActionResult<EventDto>> GetById(int id) {

            var dtoEvent =await _eventService.GetById(id);
            return Ok(dtoEvent);

        }

        [HttpPatch("Update An Event")]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventService.Update(eventPatch);
            return Ok(eventEntity);
        }


        [HttpDelete("Delete An Event")]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventService.Delete(id);
            return NoContent();
        }


        [HttpPost("Add An Event")]
        public async Task<ActionResult<EventDtoAdd>> Add(EventDtoAdd eventDtoAdd)
        {
            var eventId = await _eventService.Add(eventDtoAdd);
            return Ok(eventId);
        }
        

    }

}



