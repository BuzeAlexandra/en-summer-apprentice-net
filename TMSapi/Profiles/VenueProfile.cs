using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;

namespace TMSapi.Profiles
{
	public class VenueProfile : Profile
	{
		public VenueProfile()
		{
            CreateMap<Venue, VenueDto>().ReverseMap();
            CreateMap<Venue, VenuePatchDto>().ReverseMap();
            CreateMap<Venue, VenueDtoAdd>().ReverseMap();
        }
	}
}

