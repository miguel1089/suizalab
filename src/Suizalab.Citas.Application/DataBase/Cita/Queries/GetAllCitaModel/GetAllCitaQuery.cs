using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Suizalab.Citas.Application.DataBase.Cita.Queries.GetAllCitaModel
{
    public class GetAllCitaQuery: IGetAllCitaQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllCitaQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<List<GetAllCitaModel>> Execute()
        {
            var listaEntity = await _dataBaseService.Cita.ToListAsync();
            return _mapper.Map<List<GetAllCitaModel>>(listaEntity);
        }
    }
}
