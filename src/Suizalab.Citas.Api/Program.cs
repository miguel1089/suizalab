using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Suizalab.Citas.Api;
using Suizalab.Citas.Application;
using Suizalab.Citas.Application.DataBase;
using Suizalab.Citas.Common;
using Suizalab.Citas.External;
using Suizalab.Citas.Persistence;
using Suizalab.Citas.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseAuthentication();
app.UseAuthorization();



//app.MapPost("/CreateTest", async (IDataBaseService _dataBaseService) =>
//{
//    var entity = new Suizalab.Citas.Domain.Entities.Cita.CitaEntity
//    {
//        IdTipoDocumento = 0,
//        NumeroDocumento = "12345678",
//        NombreCompleto = "Miguel Atarama",
//        IdEspecialidad = 0,
//        FechaRegistro = DateTime.Now
//    };
//    await _dataBaseService.Cita.AddAsync(entity);
//    await _dataBaseService.SaveAsync();
//    return "Create ok";
//});

//app.MapGet("/TestGet", async (IDataBaseService _dataBaseService) =>
//{
//    var result = await _dataBaseService.Cita.ToListAsync();
//    return result;
//});

app.MapControllers();
app.Run();

