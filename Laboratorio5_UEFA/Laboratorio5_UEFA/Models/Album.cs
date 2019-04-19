using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Models
{
    public class estampa
    {
        public string tipo { get; set; }
        public int numero { get; set; }
        public bool disponible { get; set; }
    }
    public class album
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
            if (finded.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class coleccion
    {
        public string tipo { get; set; }
        public List<carta> disponibles = new List<carta>();
        public List<carta> cambios = new List<carta>();
        public List<carta> faltantes = new List<carta>();


        public void insetaradquisicion(int numero)
        {
            carta temp = new carta(numero);
            if (BuscarRepetida(numero) == true)
            {
                cambios.Add(temp);
            }
            else
            {
                disponibles.Add(temp);
            }
        }
        public bool BuscarRepetida(int num)
        {
            List<carta> finded = disponibles.FindAll(x => x.numero.Equals(num));
            if (finded.Count != 0)
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
