using AutoMapper;
using Suizalab.Citas.Domain.Entities.Cita;

namespace Suizalab.Citas.Application.DataBase.Cita.Commands.CreateCita
{
    public class CreateCitaCommand: ICreateCitaCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateCitaCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<CreateCitaModel> Execute(CreateCitaModel model)
        {
            var entity = _mapper.Map<CitaEntity>(model);
            await _dataBaseService.Cita.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
