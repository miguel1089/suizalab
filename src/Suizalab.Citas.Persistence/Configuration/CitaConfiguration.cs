using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suizalab.Citas.Domain.Entities.Cita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Persistence.Configuration
{
    public class CitaConfiguration
    {
        public CitaConfiguration(EntityTypeBuilder<CitaEntity> entityBuilder) 
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x=> x.IdTipoDocumento).IsRequired();
            entityBuilder.Property(x => x.NumeroDocumento).IsRequired();
            entityBuilder.Property(x => x.NombreCompleto).IsRequired();
            entityBuilder.Property(x => x.IdEspecialidad).IsRequired();
            entityBuilder.Property(x => x.FechaRegistro).IsRequired();
        }
    }
}
