using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Profiles;

public class EventProfile : Profile
{

	public EventProfile()
	{
		CreateMap<Event,EventDto>().ReverseMap();
        CreateMap<Event, EventPatchDto>().ReverseMap();
		CreateMap<Event, EventDtoAdd>().ReverseMap();
    }

}

