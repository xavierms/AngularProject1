using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface IAsignacionesCon
    {
        void Actualizar(Asignaciones model, int id);
        void Añadir(Asignaciones model);
        void Borrar(int? id);
        Asignaciones BuscarPorID(int id);
        IEnumerable<Asignaciones> Lists();
    }
}