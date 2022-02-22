using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IMapper mapper;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await this.eventRepository.GetByIdAsync(request.EventId);
            await this.eventRepository.DeleteAsync(eventToDelete);
            return Unit.Value;


        }
    }
}
