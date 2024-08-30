using Dls.Erp.Application.DTO;
using FluentValidation;

namespace Dls.Erp.Application.Validator
{
    public class UserDtoValidator : AbstractValidator<UsersDTO>
    {
        public UserDtoValidator() {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
