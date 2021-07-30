using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class Trabajador
    {

        public int Trabajadorid { get; set; }

        public string TrabajadorNum { get; set; }

        public string TrabajadorNomb { get; set; }
        public string TrabajadorTarif { get; set; }
        public string Oficio { get; set; }

        public string TrabajadorSuper { get; set; }



    }
}
