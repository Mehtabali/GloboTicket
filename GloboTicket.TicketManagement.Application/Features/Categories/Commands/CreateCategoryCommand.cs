﻿using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
