using Microsoft.EntityFrameworkCore;


namespace Suizalab.Citas.Application.DataBase.Cita.Commands.DeleteCita
{
    public class DeleteCitaCommand: IDeleteCitaCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteCitaCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(int Id)
        {
            var entity = await _dataBaseService.Cita.FirstOrDefaultAsync(x => x.Id == Id);
            if(entity == null)
            {
                return false;
            }
            _dataBaseService.Cita.Remove(entity);
            return await _dataBaseService.SaveAsync();
        }
    }
}
