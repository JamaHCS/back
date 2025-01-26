using FluentValidation;

namespace Domain.DTO.Roles
{
    public class UpdateRoleDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateRoleDTOValidator : AbstractValidator<UpdateRoleDTO>
    {
        public UpdateRoleDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(250);
        }
    }
}
