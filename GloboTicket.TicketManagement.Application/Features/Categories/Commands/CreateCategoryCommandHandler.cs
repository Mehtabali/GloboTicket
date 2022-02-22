using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors.AddRange(validationResult.Errors.Select(validationError => validationError.ErrorMessage));
            }

            if (createCategoryCommandResponse.Success)
            {
                var category = new Category { Name = request.Name };
                category = await this.categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = mapper.Map<CreateCategoryDto>(category);              
            }
            return createCategoryCommandResponse;
        }
    }
}
