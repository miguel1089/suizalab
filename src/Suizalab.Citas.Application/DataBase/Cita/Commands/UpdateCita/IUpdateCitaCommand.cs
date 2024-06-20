using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita
{
    public interface IUpdateCitaCommand
    {
        Task<UpdateCitaModel> Execute(UpdateCitaModel model);
    }
}
