using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Bussiness.Models.Books
{
    public class BookValidation: AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("The field {PropertyName} is required")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(t => t.Author)
                .MaximumLength(50)
                .WithMessage("The field {PropertyName} must be at most {MaxLength} characters");

            RuleFor(t => t.Category)
                .NotEmpty()
                .WithMessage("The field {PropertyName} is required")
                .MaximumLength(25)
                .WithMessage("The field {PropertyName} must be at most {MaxLength} characters");

            RuleFor(t => t.IsRented)
                .NotNull()
                .WithMessage("The field {PropertyName} is required");

            RuleFor(t => t.CreatedAt)
                .NotNull()
                .WithMessage("The field {PropertyName} is required");

            RuleFor(t => t.UpdatedAt)
                .NotNull()
                .WithMessage("The field {PropertyName} is required");

            RuleFor(t => t.Status)
                .NotEmpty()
                .WithMessage("The field {PropertyName} is required")
                .MaximumLength(25)
                .WithMessage("The field {PropertyName} must be at most {MaxLength} characters");

            RuleFor(t => t.CoverPath)
                .MaximumLength(255)
                .WithMessage("The field {PropertyName} must be at most {MaxLength} characters");
        }
    }
}
