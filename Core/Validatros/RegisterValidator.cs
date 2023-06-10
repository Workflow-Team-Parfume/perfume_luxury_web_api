using Core.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validatros
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
              .NotEmpty()
              .MinimumLength(2);

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(2);
            
            RuleFor(x => x.PhoneNumber)
                 .MinimumLength(2);
            
            RuleFor(x => x.Location)
                .NotEmpty()
                .MinimumLength(2);
        }
    }
}
