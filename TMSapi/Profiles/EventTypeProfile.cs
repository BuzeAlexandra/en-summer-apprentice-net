﻿using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Profiles
{
	public class EventTypeProfile : Profile
	{
		public EventTypeProfile()
		{
            CreateMap<EventType, EventTypeDto>().ReverseMap();
            CreateMap<EventType, EventTypePatchDto>().ReverseMap();
            CreateMap<EventType, EventTypeDtoAdd>().ReverseMap();
        }
    }
}

