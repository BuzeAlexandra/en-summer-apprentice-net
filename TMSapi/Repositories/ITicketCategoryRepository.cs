using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public interface ITicketCategoryRepository
	{
        Task<IEnumerable<TicketCategory>> GetAll();
        Task<TicketCategory> GetById(int id);
    }
}

