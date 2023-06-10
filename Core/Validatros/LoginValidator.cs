using Core.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validatros
{
    public class LoginValidators : AbstractValidator<LoginDto>
    {
        public LoginValidators()
        {
            RuleFor(x => x.Username)
              .NotEmpty()
              .MinimumLength(2);

            RuleFor(x => x.Password)
                .NotEmpty();
               


        }
    }
}
