using FluentValidation;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;


namespace Suizalab.Citas.Application.Validators.Cita
{
    public class CreateCitaValidator: AbstractValidator<CreateCitaModel>
    {
        public CreateCitaValidator() 
        {
            RuleFor(x => x.IdTipoDocumento);
            RuleFor(x => x.NumeroDocumento).NotNull().WithMessage("El campo no puede ser nulo.")
                .NotEmpty()
                .MaximumLength(12);
            RuleFor(x => x.NombreCompleto).NotNull()
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
