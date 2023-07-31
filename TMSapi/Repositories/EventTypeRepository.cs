using System;
using Microsoft.EntityFrameworkCore;
using TMSapi.Exceptions;
using TMSapi.Models;

namespace TMSapi.Repositories
{
  
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly ProjectContext _dbContext;
        public EventTypeRepository()
		{

            _dbContext = new ProjectContext();
        }

        public async Task<int> Add(EventType eventType)
        {
            _dbContext.Add(eventType);
            _dbContext.SaveChanges();
            return eventType.EventTypeId;

        }

        public async Task Delete(EventType eventType)
        {
            _dbContext.Remove(eventType);
            _dbContext.SaveChanges();

        }

        public async Task<IEnumerable<EventType>> GetAll()
        {
            var events = _dbContext.EventTypes;
            return events;
        }

        public async Task<EventType> GetById(int id)
        {
            var @event = await _dbContext.EventTypes.Where(e => e.EventTypeId == id).FirstOrDefaultAsync();
            if (@event == null)
            {
                throw new EntityNotFoundException(id, nameof(EventType));
            }

            return @event;
        }

        public async Task Update(EventType eventType)
        {

            _dbContext.Entry(eventType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

