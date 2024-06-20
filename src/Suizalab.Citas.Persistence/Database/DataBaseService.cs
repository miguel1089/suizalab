using Microsoft.EntityFrameworkCore;
using Suizalab.Citas.Application.DataBase;
using Suizalab.Citas.Domain.Entities.Cita;
using Suizalab.Citas.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Persistence.Database
{
    public class DataBaseService: DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<CitaEntity> Cita { get; set; }
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new CitaConfiguration(modelBuilder.Entity<CitaEntity>());
        }
    }
}
