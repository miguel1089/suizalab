using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.Validators.Cita
{
    public class GetCitaByDocumentoValidator: AbstractValidator<(string,string)>
    {
        public GetCitaByDocumentoValidator()
        {
            RuleFor(x => x.Item1).NotNull()
                .NotEmpty()
                .MaximumLength(12);

        }
    }
}
