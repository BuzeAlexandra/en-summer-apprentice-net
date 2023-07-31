using System;
namespace TMSapi.Models.Dto
{
	public class OrderDto
	{
        public int OrderId{ get; set; }

        public int UserId { get; set; }

        public int TicketCategoryId { get; set; }

        public DateTime OrderedAt { get; set; }

        public int NumberOfTickets { get; set; }

        public int TotalPrice { get; set; }

        public string TicketCategory { get; set; }

        public string User { get; set; }
    }
}

