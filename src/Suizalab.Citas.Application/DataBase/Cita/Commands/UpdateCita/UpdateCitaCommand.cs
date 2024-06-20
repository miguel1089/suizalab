using AutoMapper;
using Suizalab.Citas.Domain.Entities.Cita;

namespace Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita
{
    public class UpdateCitaCommand: IUpdateCitaCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateCitaCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<UpdateCitaModel> Execute(UpdateCitaModel model)
        {
            var entity = _mapper.Map<CitaEntity>(model);
            _dataBaseService.Cita.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
