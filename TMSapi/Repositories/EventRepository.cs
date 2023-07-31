using System;
using Microsoft.EntityFrameworkCore;
using TMSapi.Exceptions;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Repositories
{
    public class EventRepository : IEventRepository

    {
        private readonly ProjectContext _dbContext;
        public EventRepository() {
            _dbContext = new ProjectContext();
        }

        public async Task<int> Add(Event @event)
        {
   
            _dbContext.Add(@event);
            _dbContext.SaveChanges();
            return @event.EventId;


        }

        public async Task Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
            
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();
            if (@event == null) {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            
            return @event;
        }

        public async Task Update(Event @event)
        {
            
            _dbContext.Entry(@event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

    }
}

