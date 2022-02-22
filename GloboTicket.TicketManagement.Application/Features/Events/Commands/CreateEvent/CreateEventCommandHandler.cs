using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(this.eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = this.mapper.Map<Event>(request);
            @event = await this.eventRepository.AddAsync(@event);

            var email = new Email 
            { 
                To = "mehtabali@live.com",
                Body = $"A new event was created: {request}", 
                Subject ="A new event created"
            };
            try
            {
                await this.emailService.SendEmail(email);
            }
            catch (Exception)
            {
                //This should not stop API from doing the core operation 
                //i.e. creation of new event; though it will be logged
                
            }
            return @event.EventId;
        }
    }
}
