using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        int Add(Order @orders);
        void Update(Order orders);
        void Delete(Order @orders);
        
    }
}