using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public interface IEventRepository
	{
		Task<IEnumerable<Event>> GetAll();
		Task<Event> GetById(int id);
        int Add(Event @event);
		void Update(Event @event);
		void Delete(Event @event);

	}
}

