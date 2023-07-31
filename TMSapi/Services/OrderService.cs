using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Serices
{
	public class OrderService :IOrderService
	{
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
		{
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
		}

        public async Task<int> Add(OrderDtoAdd orderDtoAdd)
        {

            if (orderDtoAdd == null)
            {
                throw new ArgumentNullException(nameof(orderDtoAdd), "OrderDto is null.");
            }

            if (orderDtoAdd.NumberOfTickets == 0)
            {
                throw new ArgumentException("Number of tickets cannot be zero.");
            }

            var @ticketCategory = await _ticketCategoryRepository.GetById(orderDtoAdd.TicketCategoryId);

            if (@ticketCategory == null)
            {
                throw new InvalidOperationException($"Ticket category with ID {orderDtoAdd.TicketCategoryId} not found in the database.");
            }

            var newSum = orderDtoAdd.NumberOfTickets * @ticketCategory.Price;

            var newOrder = _mapper.Map<Order>(orderDtoAdd);
            newOrder.OrderedAt = DateTime.Now;
            newOrder.TotalPrice = newSum;

            _orderRepository.Add(newOrder);
            return newOrder.OrderId;
        }

        public async Task Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                throw new InvalidOperationException($"Item with ID {id} not found in the database.");
            }
            else
            {
                _orderRepository.Delete(orderEntity);
            }
          
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            var dtoOrder = _mapper.Map<List<OrderDto>>(orders);
            return dtoOrder;
        }

        public async Task<OrderDto> GetById(int id)
        {
            var @orders = await _orderRepository.GetById(id);

            if (@orders == null)
            {
                throw new InvalidOperationException($"Item with ID {id} not found in the database.");

            }

            var dtoOrder = _mapper.Map<OrderDto>(@orders);
            return dtoOrder;
        }

        public async Task<Order> Update(OrderPatchDto orderPatchDto)
        {
            if (orderPatchDto == null)
            {
                throw new ArgumentNullException(nameof(orderPatchDto), "OrderPatchDto is null.");
            }

            if (orderPatchDto.NumberOfTickets == 0)
            {
                throw new ArgumentException("Number of tickets must be greater than zero.");
            }

            var existingOrder = await _orderRepository.GetById(orderPatchDto.OrderId);

            if (existingOrder == null)
            {
                throw new InvalidOperationException($"Order with ID {orderPatchDto.OrderId} not found in the database.");
            }

            var ticketCategory = await _ticketCategoryRepository.GetById(orderPatchDto.TicketCategoryId);

            if (ticketCategory == null)
            {
                throw new InvalidOperationException($"Ticket category with ID {orderPatchDto.TicketCategoryId} not found in the database.");
            }
            var newSum = orderPatchDto.NumberOfTickets * ticketCategory.Price;

            _mapper.Map(orderPatchDto, existingOrder);
            existingOrder.TotalPrice = newSum;
            _orderRepository.Update(existingOrder);

            return existingOrder;
        }
    }
}

