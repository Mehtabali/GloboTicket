using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        public readonly IAsyncRepository<Event> eventRepository;
        public readonly IAsyncRepository<Category> categoryRepository;
        public readonly IMapper mapper;
        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            this.eventRepository = eventRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await this.eventRepository.GetByIdAsync(request.Id);
            var eventDetailDto = this.mapper.Map<EventDetailVm>(@event);

            var category = await this.categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailDto.Category = this.mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}
