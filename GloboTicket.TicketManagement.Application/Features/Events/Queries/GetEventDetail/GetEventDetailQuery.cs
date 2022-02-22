using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Events.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
