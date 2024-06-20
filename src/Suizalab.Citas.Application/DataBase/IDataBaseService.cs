using Microsoft.EntityFrameworkCore;
using Suizalab.Citas.Domain.Entities.Cita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase
{
    public interface IDataBaseService
    {
        public DbSet<CitaEntity> Cita { get; set; }
        Task<bool> SaveAsync();
    }
}
