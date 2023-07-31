using System;
using System.Collections.Generic;

namespace TMSapi.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int TicketCategoryId { get; set; }

    public int? NumberOfSoldTickets { get; set; }

    public int? TotalPriceOnCategory { get; set; }
}
