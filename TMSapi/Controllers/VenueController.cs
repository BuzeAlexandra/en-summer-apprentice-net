using System;
using Microsoft.AspNetCore.Mvc;
using TMSapi.Models.Dto;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMSapi.Serices;

namespace TMSapi.Controllers
{


	[Route("api/[controller]/[action]")]
        [ApiController]
	public class VenueController: ControllerBase { 

	private readonly IVenueService _venueService;

    public VenueController( IVenueService venueService) 
		{
	
			_venueService=venueService;
		}


        [HttpGet]
        public async Task<ActionResult<List<VenueDto>>> GetAll()
        {

            var dtoVenue = await _venueService.GetAll();
            return Ok(dtoVenue);

        }


        [HttpGet]

        public async Task<ActionResult<VenueDto>> GetById(int id)
        {

            var dtoVenue = await _venueService.GetById(id);
            return Ok(dtoVenue);

        }

        [HttpPatch]
        public async Task<ActionResult<VenuePatchDto>> Patch(VenuePatchDto venuePatchDto)
        {
            var venueEntity = await _venueService.Update(venuePatchDto);
            return Ok(venueEntity);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _venueService.Delete(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<VenueDtoAdd>> Add(VenueDtoAdd venueDtoAdd)
        {
            var venueId= await _venueService.Add(venueDtoAdd);
            return Ok(venueId);
        }
    }


}

