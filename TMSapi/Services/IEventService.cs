using System;
using Microsoft.AspNetCore.Mvc;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Serices
{
	public interface IEventService
	{
        Task<IEnumerable<EventDto>> GetAll();
        Task<EventDto> GetById(int id);
        Task <int> Add(EventDtoAdd eventDtoAdd);
        Task<Event> Update(EventPatchDto eventPatch);
        Task Delete(int id);
        
    }
}

