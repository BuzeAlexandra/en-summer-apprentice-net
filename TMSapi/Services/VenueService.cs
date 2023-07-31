using System;
using AutoMapper;
using TMSapi.Models;
using TMSapi.Models.Dto;
using TMSapi.Repositories;

namespace TMSapi.Serices
{
	public class VenueService : IVenueService
	{
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;

        public VenueService(IVenueRepository venueRepository, IMapper mapper)
		{
            _venueRepository = venueRepository;
            _mapper = mapper;

		}

        public async Task<int> Add(VenueDtoAdd venueDtoAdd)
        {
            var venue = _mapper.Map<Venue>(venueDtoAdd);
             await _venueRepository.Add(venue);
            return venue.VenueId;
        }

        public async Task Delete(int id)
        {
            var venueEntity = await _venueRepository.GetById(id);

            if (venueEntity != null)
            {
               await _venueRepository.Delete(venueEntity);
            }
            else
            {
                throw new InvalidOperationException($"Item with ID {id} not found in the database.");
            }
        }

        public async Task<IEnumerable<VenueDto>> GetAll()
        {
            var venues = await _venueRepository.GetAll();

            var dtoVenues = _mapper.Map<IEnumerable<VenueDto>>(venues);

            return dtoVenues;
        }

        public async Task<VenueDto> GetById(int id)
        {
            var venues = await _venueRepository.GetById(id);

            if (venues == null)
            {
                throw new InvalidOperationException($"Item with ID {venues.VenueId} not found in the database");

            }

            var venueDto = _mapper.Map<VenueDto>(venues);
            return venueDto;
        }

        public async Task<Venue> Update(VenuePatchDto venuePatchDto)
        {
            var venueEntity = await _venueRepository.GetById(venuePatchDto.VenueId);
            if (venueEntity == null)
            {
                throw new InvalidOperationException($"Item with ID {venuePatchDto.VenueId} not found in the database");
            }
            _mapper.Map(venuePatchDto, venueEntity);
            await _venueRepository.Update(venueEntity);

            return venueEntity;
        }
    }
}

