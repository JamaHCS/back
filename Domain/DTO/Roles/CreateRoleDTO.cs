using FluentValidation;

namespace Domain.DTO.Roles
{
    public record CreateRoleDTO
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public IEnumerable<Guid> PermissionIds { get; init; } = new List<Guid>();
    }

    public class CreateRoleDTOValidator : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(250);

            RuleFor(x => x.PermissionIds)
                .NotEmpty().WithMessage("El rol debe de tener al menos un permiso asociado.");
        }
    }
}
