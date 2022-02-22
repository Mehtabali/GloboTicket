using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IMapper mapper;
        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventUpdate = await this.eventRepository.GetByIdAsync(request.EventId);
            //TODO:: Need to explore this way of map method usage 
            this.mapper.Map(request, eventUpdate, typeof(UpdateEventCommand), typeof(Event));
            await this.eventRepository.UpdateAsync(eventUpdate);
            return Unit.Value;
        }
    }
}
