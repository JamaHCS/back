using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using FluentValidation;

namespace Domain.Validations
{
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
