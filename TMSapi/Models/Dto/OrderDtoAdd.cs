using System;
namespace TMSapi.Models.Dto
{
	public class OrderDtoAdd
	{

        public int UserId { get; set; }

        public int TicketCategoryId { get; set; }

        public DateTime OrderedAt { get; set; }

        public int NumberOfTickets { get; set; }

       // public int TotalPrice { get; set; }
    }
}

