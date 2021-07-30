using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface ITrabajadorCon
    {
        void Actualizar(Trabajador model, int id);
        void Añadir(Trabajador model);
        void Borrar(int? id);
        Trabajador BuscarPorID(int id);
        IEnumerable<Trabajador> Lists();
    }
}