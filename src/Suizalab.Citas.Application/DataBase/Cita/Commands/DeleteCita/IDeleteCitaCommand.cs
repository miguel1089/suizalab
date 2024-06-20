

namespace Suizalab.Citas.Application.DataBase.Cita.Commands.DeleteCita
{
    public interface IDeleteCitaCommand
    {
        Task<bool> Execute(int Id);
    }
}
