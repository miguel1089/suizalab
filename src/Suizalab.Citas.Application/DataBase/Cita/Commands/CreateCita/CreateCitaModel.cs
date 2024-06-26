﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita
{
    public class CreateCitaModel
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
