using System;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Serices
{
	public interface IOrderService
	{
        Task<IEnumerable<OrderDto>> GetAll();
        Task<OrderDto> GetById(int id);
        Task<int> Add(OrderDtoAdd orderDtoAdd);
        Task<Order> Update(OrderPatchDto orderPatchDto);
        Task Delete(int id);
    }
}

