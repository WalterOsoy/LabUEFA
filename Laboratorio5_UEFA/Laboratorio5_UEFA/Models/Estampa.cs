using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Models
{
    public class Estampa : IComparable
    {
        public string tipo { get; set; }
        public int numero { get; set; }
        public Estampa() { }
        public Estampa(string type, int num)
        {
            this.tipo = type;
            this.numero = num;
        }
        public int CompareTo(object obj)
        {
            Estampa tempo = new Estampa();
            return this.numero.CompareTo(tempo.numero);
        }
    }
}
