using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;

        public OrderController(IOrderRepository orderRepository, IMapper mapper,ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpGet("Get All Orders")]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            var dtoOrder = _mapper.Map<List<Order>>(orders);
            return Ok(orders);

        }

        [HttpGet("Get Orders by Id")]

        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @orders = await _orderRepository.GetById(id);

            if (@orders == null)
            {
                return NotFound();

            }

            var dtoOrder = _mapper.Map<OrderDto>(@orders);
            return Ok(dtoOrder);

        }

        [HttpPatch("Update Order")]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            if (orderPatch == null)
            {
                return NotFound();
            }

            if (orderPatch.NumberOfTickets == 0)
            {
                return BadRequest("Number of tickets must be greater than zero.");
            }

            var existingOrder = await _orderRepository.GetById(orderPatch.OrderId);

            if (existingOrder == null)
            {
                return NotFound();
            }

            var ticketCategory = await _ticketCategoryRepository.GetById(orderPatch.TicketCategoryId);

            if (ticketCategory == null)
            {
                return NotFound();
            }
            var newSum = orderPatch.NumberOfTickets * ticketCategory.Price;

            existingOrder.TicketCategoryId = orderPatch.TicketCategoryId;
            existingOrder.NumberOfTickets = orderPatch.NumberOfTickets;
            existingOrder.TotalPrice = newSum;

            _orderRepository.Update(existingOrder);

            return Ok(existingOrder.OrderId);
        }

        [HttpDelete("Delete Order")]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
       
        [HttpPost("Add Order")]
        public async Task<ActionResult<OrderDtoAdd>> Add(OrderDtoAdd orderDtoAdd)
        {

            if (orderDtoAdd == null)
            {
                return NotFound();
            }

            if (orderDtoAdd.NumberOfTickets == 0)
            {
                return NotFound();
            }

            var @ticketCategory = await _ticketCategoryRepository.GetById(orderDtoAdd.TicketCategoryId);

            if (@ticketCategory == null)
            {
                return NotFound();
            }

            var newSum = orderDtoAdd.NumberOfTickets * @ticketCategory.Price;

            var newOrder = new Order()
            {
      
                UserId = orderDtoAdd.UserId,
                TicketCategoryId = orderDtoAdd.TicketCategoryId,
                OrderedAt = DateTime.Now,
                NumberOfTickets = orderDtoAdd.NumberOfTickets,
                TotalPrice = newSum
            };

            _orderRepository.Add(newOrder);
            return Ok(newOrder.OrderId);
        }

    }
}