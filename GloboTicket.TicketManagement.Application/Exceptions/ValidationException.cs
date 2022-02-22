using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public List<string> ValidationErrors { get; } = new();
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
