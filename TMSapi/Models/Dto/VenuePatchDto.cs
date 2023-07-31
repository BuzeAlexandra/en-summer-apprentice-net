using System;
namespace TMSapi.Models.Dto
{
	public class VenuePatchDto
	{
        public int VenueId { get; set; }

        public string Location { get; set; } = null!;

        public string Type { get; set; } = null!;

        public int Capacity { get; set; }
    }
}

