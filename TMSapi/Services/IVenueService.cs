using System;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Serices
{
	public interface IVenueService
	{
        Task<IEnumerable<VenueDto>> GetAll();
        Task<VenueDto> GetById(int id);
        Task<int> Add(VenueDtoAdd venueDtoAdd);
        Task<Venue> Update(VenuePatchDto venuePatchDto);
        Task Delete(int id);
    }
}

