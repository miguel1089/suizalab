using FluentValidation;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.Validators.Cita
{
    public class UpdateCitaValidator : AbstractValidator<UpdateCitaModel>
    {
        public UpdateCitaValidator() 
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.IdTipoDocumento).NotNull().GreaterThan(0);
            RuleFor(x => x.NumeroDocumento).NotNull()
                .NotEmpty()
                .MaximumLength(12);
            RuleFor(x => x.NombreCompleto).NotNull()
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(x => x.IdEspecialidad).NotNull().GreaterThan(0);
        }
    }
}
