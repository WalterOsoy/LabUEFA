using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Models
{
    public class Album
    {
        public string tipo { get; set; }
        public List<carta> numero = new List<carta>();
        public void insertarNumero(int num)
        {
            carta temp = new carta(num);
            if (!BuscarCarta(num))
            {
                numero.Add(temp);
            }
        }
        public bool BuscarCarta(int num)
        {
            List<carta> finded = numero.FindAll(x => x.numero.Equals(num));
            if (finded.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class carta : IComparable
    {
        public int numero { get; set; }
        public carta() { }
        public carta(int num)
        {
            this.numero = num;
        }
        public int CompareTo(object obj)
        {
            carta tempo = new carta();
            return this.numero.CompareTo(tempo.numero);
        }
    }
}
