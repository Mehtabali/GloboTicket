using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}