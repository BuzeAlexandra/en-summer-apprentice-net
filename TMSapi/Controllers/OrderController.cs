using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;
using TMSapi.Serices;

namespace TMSapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IOrderService _orderService;

        public OrderController(IOrderRepository orderRepository, IMapper mapper,ITicketCategoryRepository ticketCategoryRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
            _orderService = orderService;
        }

        [HttpGet("Get All Orders")]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {

            var dtoOrder = await _orderService.GetAll();
            return Ok(dtoOrder);

        }

        [HttpGet("Get Orders by Id")]

        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var dtoOrder = await _orderService.GetById(id);
            return Ok(dtoOrder);

        }

        [HttpPatch("Update Order")]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var eventEntity = await _orderService.Update(orderPatch);
            return Ok(eventEntity);
        }

        [HttpDelete("Delete Order")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return NoContent();
        }
       
        [HttpPost("Add Order")]
        public async Task<ActionResult<OrderDtoAdd>> Add(OrderDtoAdd orderDtoAdd)
        {
            var order= await _orderService.Add(orderDtoAdd);
            return Ok(order);
        }

    }
}