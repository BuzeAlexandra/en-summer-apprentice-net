using System;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Services
{
	public interface IEventTypeService
	{
        Task<IEnumerable<EventTypeDto>> GetAll();
        Task<EventTypeDto> GetById(int id);
        Task<int> Add(EventTypeDtoAdd eventTypeDtoAdd);
        Task<EventType> Update(EventTypePatchDto eventTypePatch);
        Task Delete(int id);
    }
}

