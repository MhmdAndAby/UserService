using FluentValidation;
using UserService.Api.Controllers.ViewModel;

namespace UserService.Api.Validators
{
    public class CreateUserValidator:AbstractValidator<CreateUserViewModel>
    {
        public CreateUserValidator() {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName cannot be empty")
                .MinimumLength(5).WithMessage("Minimum lengths is 5 characters")
                .MaximumLength(50).WithMessage("Maximum lengths is 50 characters")
                .Matches("^[a-zA-Z]+$").WithMessage("First name must contain only letters without spaces or special characters."); ;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName cannot be empty")
                .MinimumLength(5).WithMessage("Minimum lengths is 5 characters")
                .MaximumLength(50).WithMessage("Maximum lengths is 50 characters")
                .Matches("^[a-zA-Z]+$").WithMessage("First name must contain only letters without spaces or special characters.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number cannot be empty")
                .Length(11).WithMessage("The length of phone number should be 11 characters");
        }
    }
}
