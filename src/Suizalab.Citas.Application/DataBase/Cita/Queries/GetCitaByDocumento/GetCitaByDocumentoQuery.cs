using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suizalab.Citas.Application.DataBase.Cita.Queries.GetCitaByDocumento
{
    public class GetCitaByDocumentoQuery: IGetCitaByDocumentoQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetCitaByDocumentoQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<List<GetCitaByDocumentoModel>> Execute(string numeroDocumento)
        {
            var entity = await _dataBaseService.Cita.
                FirstOrDefaultAsync(x => x.NumeroDocumento.Equals(numeroDocumento));
            return _mapper.Map<List<GetCitaByDocumentoModel>>(entity);
        }
    }
}
