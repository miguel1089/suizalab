using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel
{
    public interface IGetAllCitaQuery
    {
        Task<List<GetAllCitaModel>> Execute();
    }
}
