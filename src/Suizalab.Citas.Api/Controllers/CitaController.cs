using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita;
using Suizalab.Citas.Application.DataBase.Cita.Commands.DeleteCita;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel;
using Suizalab.Citas.Application.DataBase.Cita.Queries.GetCitaByDocumento;
using Suizalab.Citas.Application.Exceptions;
using Suizalab.Citas.Application.Features;
using System.ComponentModel.DataAnnotations;

namespace Suizalab.Citas.Api.Controllers
{
    [Authorize]
    [Route("api/v1/cita")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CitaController : ControllerBase
    {
        public CitaController() 
        {
        
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCitaModel model, 
            [FromServices] ICreateCitaCommand createCitaCommand,
            [FromServices] IValidator<CreateCitaModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await createCitaCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created,data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> update([FromBody] UpdateCitaModel model, 
            [FromServices] IUpdateCitaCommand updateCitaCommand,
            [FromServices] IValidator<UpdateCitaModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await updateCitaCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id, [FromServices] IDeleteCitaCommand deleteCitaCommand)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await deleteCitaCommand.Execute(id);
            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> getAll([FromServices] IGetAllCitaQuery getAllCitaQuery)
        {
            var data = await getAllCitaQuery.Execute();
            if (data == null || data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }

        [HttpGet("get-by-documento/{documento}")]
        public async Task<IActionResult> getByDocumento(string numeroDocumento, 
            [FromServices] IGetCitaByDocumentoQuery getCitaByDocumentoQuery,
            [FromServices] IValidator<(string,string)> validator)
        {
            var validate = await validator.ValidateAsync((numeroDocumento,string.Empty));
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            if (string.IsNullOrEmpty(numeroDocumento))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await getCitaByDocumentoQuery.Execute(numeroDocumento);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
        }
    }
}
