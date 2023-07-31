using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public interface IEventRepository
	{
		Task<IEnumerable<Event>> GetAll();
		Task<Event> GetById(int id);
        Task<int> Add(Event @event);
		Task Update(Event @event);
		Task Delete(Event @event);

	}
}

