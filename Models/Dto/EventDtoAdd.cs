using System;
namespace TMSapi.Models.Dto
{
	public class EventDtoAdd
	{

        public int VenueId { get; set; }

        public int EventTypeId { get; set; }

        public string EventDescription { get; set; } = null!;

        public string EventName { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

