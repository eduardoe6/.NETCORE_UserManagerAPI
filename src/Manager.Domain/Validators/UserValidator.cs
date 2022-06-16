using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("A entidade não pode ser vazia")
                            .NotNull().WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório")
                                .NotNull().WithMessage("O nome não pode ser vazio")
                                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres")
                                .MaximumLength(80).WithMessage("O nome deve ter no máximo 80 caracteres");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O email é obrigatório").NotNull().WithMessage("O email não pode ser vazio")
                                 .MinimumLength(3).WithMessage("O email deve ter no mínimo 10 caracteres")
                                 .MaximumLength(80).WithMessage("O email deve ter no máximo 180 caracteres")
                                 .Matches("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$").WithMessage("Email inválido");

            RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória").NotNull().WithMessage("A senha não pode ser vazia")
                                    .MinimumLength(3).WithMessage("A senha deve ter no mínimo 6 caracteres")
                                    .MaximumLength(80).WithMessage("A senha deve ter no máximo 30 caracteres");;
        }
    }
}