using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Queries.GetCitaByDocumento
{
    public interface IGetCitaByDocumentoQuery
    {
        Task<List<GetCitaByDocumentoModel>> Execute(string numeroDocumento);
    }
}
