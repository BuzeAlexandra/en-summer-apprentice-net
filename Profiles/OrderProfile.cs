using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Profiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
            CreateMap<Order, OrderDtoAdd>().ReverseMap();
        }
	}
}

