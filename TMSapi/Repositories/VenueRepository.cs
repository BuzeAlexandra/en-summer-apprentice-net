using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMSapi.Exceptions;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public class VenueRepository : IVenueRepository
	{
        private readonly ProjectContext _dbContext;
        public VenueRepository()
		{
            _dbContext = new ProjectContext();
        }

        public async Task<int> Add(Venue venue)
        {
            _dbContext.Add(venue);
            _dbContext.SaveChanges();
            return venue.VenueId;
        }

        public async Task Delete(Venue venue)
        {
            _dbContext.Remove(venue);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Venue>> GetAll()
        {
            var venues = _dbContext.Venues;
            return venues;
        }

        public async Task<Venue> GetById(int id)
        {
            var venue = await _dbContext.Venues.Where(e => e.VenueId == id).FirstOrDefaultAsync();
            if (venue == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }

            return venue;
        }

        public async Task Update(Venue venue)
        {
            _dbContext.Entry(venue).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

