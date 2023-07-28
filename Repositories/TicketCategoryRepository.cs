using System;
using Microsoft.EntityFrameworkCore;
using TMSapi.Models;
using TMSapi.Repositories;

namespace TMSapi.Repositories
{
	public class TicketCategoryRepository : ITicketCategoryRepository

	{
        private readonly ProjectContext _dbContext;
        public TicketCategoryRepository()
		{
            _dbContext = new ProjectContext();
        }

        public async Task<IEnumerable<TicketCategory>> GetAll()
        {
            var ticketCategory = _dbContext.TicketCategories;
            return ticketCategory;
        }


        public async Task<TicketCategory> GetById(int id)
        {
            var @ticketCategory = await _dbContext.TicketCategories.Where(o => o.TicketCategoryId == id).FirstOrDefaultAsync();
            return @ticketCategory;
        }

    }
}

