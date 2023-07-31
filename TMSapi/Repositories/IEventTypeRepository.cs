using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public interface IEventTypeRepository
	{
        Task<IEnumerable<EventType>> GetAll();
        Task<EventType> GetById(int id);
        Task<int> Add(EventType eventType);
        Task Update(EventType eventType);
        Task Delete(EventType eventType);
    }
}

