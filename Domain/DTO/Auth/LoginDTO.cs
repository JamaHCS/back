using FluentValidation;

namespace Domain.DTO.Auth
{
    public record LoginDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("El correo electrónico es obligatorio.");

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
