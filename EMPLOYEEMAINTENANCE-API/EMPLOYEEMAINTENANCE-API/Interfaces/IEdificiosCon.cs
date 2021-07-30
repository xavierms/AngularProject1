using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface IEdificiosCon
    {
        void Actualizar(Edificios model, int id);
        void Añadir(Edificios model);
        void Borrar(int? id);
        Edificios BuscarPorID(int id);
        IEnumerable<Edificios> Lists();
    }
}