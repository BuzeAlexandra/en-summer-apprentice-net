using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
	public interface IVenueRepository
	{
        Task<IEnumerable<Venue>> GetAll();
        Task<Venue> GetById(int id);
        Task<int> Add(Venue venue);
        Task Update(Venue venue);
        Task Delete(Venue venue);
    }
}

