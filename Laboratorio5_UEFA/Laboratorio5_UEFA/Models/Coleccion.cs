using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Models
{
    public class Coleccion
    {
        public string tipo { get; set; }
        public List<carta> Disponibles = new List<carta>();
        public List<carta> intercambios = new List<carta>();

    }

}
