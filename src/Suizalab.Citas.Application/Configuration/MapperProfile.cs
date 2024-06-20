using AutoMapper;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;
using Suizalab.Citas.Domain.Entities.Cita;


namespace Suizalab.Citas.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            CreateMap<CitaEntity, CreateCitaModel>().ReverseMap();
            CreateMap<CitaEntity, UpdateCitaModel>().ReverseMap();
        }
    }
}
