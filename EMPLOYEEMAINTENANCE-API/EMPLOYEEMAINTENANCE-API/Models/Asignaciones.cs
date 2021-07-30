using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class Asignaciones
    {
        public int Asignacionid { get; set; }
        public string AsigNum { get; set; }
        public string AsigFechIni { get; set; }
        public string AsigNumDias { get; set; }

        public int EdificioNum_fk { get; set; }
        public int TrabajadorNum_fk { get; set; }

    }
}
