using System;
using System.Collections.Generic;

namespace TMSapi.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int TicketCategoryId { get; set; }

    public DateTime OrderedAt { get; set; }

    public int NumberOfTickets { get; set; }

    public int TotalPrice { get; set; }

    public virtual TicketCategory TicketCategory { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
