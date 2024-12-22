using FluentValidation;

namespace Domain.DTO.Auth
{
    public record RegisterDTO
    {
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
        public string MotherLastName { get; set; }
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.MiddleName)
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido paterno es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.MotherLastName)
                .NotEmpty().WithMessage("El apellido materno es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un correo válido.")
                .MaximumLength(250);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(8);
        }
    }
}
