using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;
using Suizalab.Citas.Application.DataBase.Cita.Commands.DeleteCita;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetCitaByDocumento;
using Suizalab.Citas.Application.Exceptions;
using Suizalab.Citas.Application.External.GetTokenJwt;
using Suizalab.Citas.Application.Features;
using System.ComponentModel.DataAnnotations;

namespace Suizalab.Citas.Api.Controllers
{
    [Route("api/v1/seguridad")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SeguridadController : ControllerBase
    {

        [HttpGet("get-token")]
        public async Task<IActionResult> getToken([FromServices] IGetTokenJwtService getTokenJwtService)
        {
            var idUsuario = 1;
            var token = getTokenJwtService.Execute(idUsuario.ToString());
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, token));
            
        }

    }
}
