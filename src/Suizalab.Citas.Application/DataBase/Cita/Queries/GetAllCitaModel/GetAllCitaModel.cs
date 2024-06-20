using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel
{
    public class GetAllCitaModel
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
