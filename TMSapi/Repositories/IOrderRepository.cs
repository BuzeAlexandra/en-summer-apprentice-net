﻿using System;
using TMSapi.Models;

namespace TMSapi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<int> Add(Order order);
        Task Update(Order order);
        Task Delete(Order order);

    }
}