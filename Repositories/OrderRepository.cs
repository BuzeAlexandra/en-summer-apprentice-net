using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMSapi.Exceptions;
using TMSapi.Models;
using TMSapi.Repositories;

namespace TMSapi.Repositories
{

    public class OrderRepository : IOrderRepository

    {
        private readonly ProjectContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new ProjectContext();
        }


        public int Add(Order orders)
        {
            _dbContext.Add(orders);
            _dbContext.SaveChanges();
            return orders.OrderId;
        }


        public void Delete(Order @orders)
        {
            _dbContext.Remove(@orders);
            _dbContext.SaveChanges();
        }


        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }


        public void Update(Order orders)
        {
            /*if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }

            var ticketCategory = _dbContext.TicketCategories.Find(orders.TicketCategoryId);
            if (ticketCategory == null)
            {
                throw new NotFoundException("Ticket category not found.");
            }

            if (orders.NumberOfTickets <= 0)
            {
                throw new ArgumentException("Number of tickets must be greater than zero.");
            }

            orders.TotalPrice = ticketCategory.Price * orders.NumberOfTickets;
            */
            _dbContext.Entry(orders).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<Order> GetById(int id)
        {
            var @orders = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            return @orders;
        }

      
    }
}