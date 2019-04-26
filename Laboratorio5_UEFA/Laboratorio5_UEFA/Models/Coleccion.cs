using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Models
{
    public class coleccion
    {
        public string tipo;
        public List<Estampa> Faltantes;
        public List<Estampa> Disponibles;
        public List<Estampa> Repetidas;
        public coleccion() { }
        public coleccion(string tipo, List<Estampa> missing, List<Estampa> available, List<Estampa> repeated)
        {
            this.tipo = tipo;
            this.Faltantes = missing;
            this.Disponibles = available;
            this.Repetidas = repeated;
        }
        public List<Estampa> getFaltantes()
        {
            return this.Faltantes;
        }
        public void setFalatantes(Estampa obj)
        {
            Faltantes.Add(obj);
        }
        public List<Estampa> getDisponibles()
        {
            return this.Disponibles;
        }
        public void setDisponibles(Estampa obj)
        {
            Disponibles.Add(obj);
        }
        public List<Estampa> getRepetidas()
        {
            return this.Repetidas;
        }
        public void setRepetidas(Estampa obj)
        {
            Repetidas.Add(obj);
        }
    }

}
