using FluentValidation;

namespace Domain.DTO.Roles
{
    public record UpdatePermissionsOnRoleDTO
    {
        public IEnumerable<Guid> Permissions { get; init; }
    }

    public class UpdatePermissionsOnRoleDTOValidator : AbstractValidator<UpdatePermissionsOnRoleDTO>
    {
        public UpdatePermissionsOnRoleDTOValidator()
        {
            RuleFor(x => x.Permissions)
                .NotNull().WithMessage("Necesitas definir los permisos")
                .NotEmpty().WithMessage("Necesitas definir los permisos");
        }
    }
}
