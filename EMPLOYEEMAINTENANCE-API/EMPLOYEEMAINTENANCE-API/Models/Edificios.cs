using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class Edificios
    {
        public int EdificiosId { get; set; }

        public string EdificioNum { get; set; }

        public string EdificioDireccion { get; set; }
        public string TipoEdif { get; set; }

        public string NivelCal { get; set; }

        public string Categor { get; set; }

    }
}
