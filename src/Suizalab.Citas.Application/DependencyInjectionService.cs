using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Suizalab.Citas.Application.Configuration;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;
using Suizalab.Citas.Application.DataBase.Cita.Commands.DeleteCita;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetCitaByDocumento;
using Suizalab.Citas.Application.Validators.Cita;

namespace Suizalab.Citas.Application
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());

            #region Cita
            services.AddTransient<ICreateCitaCommand, CreateCitaCommand>();
            services.AddTransient<IUpdateCitaCommand, UpdateCitaCommand>();
            services.AddTransient<IDeleteCitaCommand, DeleteCitaCommand>();
            services.AddTransient<IGetAllCitaQuery, GetAllCitaQuery>();
            services.AddTransient<IGetCitaByDocumentoQuery, GetCitaByDocumentoQuery>();
            #endregion 

            #region Validator
            services.AddScoped<IValidator<CreateCitaModel>, CreateCitaValidator>();
            services.AddScoped<IValidator<UpdateCitaModel>, UpdateCitaValidator>();
            services.AddScoped<IValidator<(string,string)>, GetCitaByDocumentoValidator>();

            #endregion

            return services;
        }
    }
}
