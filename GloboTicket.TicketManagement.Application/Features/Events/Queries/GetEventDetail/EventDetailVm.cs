using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.GetEventDetail
{
    public class EventDetailVm
    {
        public Guid EventId { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}