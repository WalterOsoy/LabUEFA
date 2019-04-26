using Laboratorio5_UEFA.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Repository
{
    public class UefaAlbum: IUefaAlbum
    {
        public string ubicacion1 = @"C:\Users\DISTELSA\Desktop\album.csv";
        public string ubicacion2 = @"C:\Users\DISTELSA\Desktop\calcomanias.csv";
        public Dictionary<string, coleccion> listados = new Dictionary<string, coleccion>();//diccionadio 1
        public Dictionary<Estampa, bool> disponibles = new Dictionary<Estampa, bool>();//diccionario 2

        public coleccion GetTeam(string id)
        {
            return listados.FirstOrDefault(x => x.Key == id).Value;//Tested
        }
        public List<coleccion> getAlbumTeams()
        {
            List<coleccion> temp = new List<coleccion>();
            foreach (var item in listados)
            {
                temp.Add(item.Value);
            }
            return temp;
        }
        public List<Estampa> ListadoTipo(string valor, int i)
        {
            List<Estampa> temporal = new List<Estampa>();
            Estampa obj2;
            string line = File.ReadLines(ubicacion1).Skip(i).Take(1).First();
            string[] data = line.Split(",");
            if (valor == data[0])
            {
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] != "")
                    {
                        obj2 = new Estampa(data[0], Convert.ToInt32(data[j]));
                        temporal.Add(obj2);
                    }
                }
            }
            return temporal;
        }

        public void LlenarListados()
        {
            int contador = 0;
            coleccion obj;
            System.IO.StreamReader reader = new System.IO.StreamReader(ubicacion2);
            while (!reader.EndOfStream)
            {
                List<Estampa> missing = new List<Estampa>();
                List<Estampa> available = new List<Estampa>();
                List<Estampa> repeated = new List<Estampa>();
                Estampa obj2;
                string line = reader.ReadLine();
                line.ToLower();
                string[] data = line.Split(",");
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] != "")
                    {
                        obj2 = new Estampa(data[0], Convert.ToInt32(data[i]));
                        Estampa tempo = available.Find(x => x.numero.Equals(obj2.numero));
                        if (tempo == null)
                        {
                            available.Add(obj2);
                        }
                        else
                        {
                            repeated.Add(obj2);
                        }
                    }
                }
                List<Estampa> temporal = ListadoTipo(data[0], contador);
                missing = ListadoTipo(data[0], contador);
                foreach (var item1 in temporal)
                {
                    foreach (var item2 in available)
                    {
                        if (item1.numero.Equals(item2.numero) == true)
                        {
                            int y = item2.numero;
                            missing.Remove(missing.Find(x => x.numero.Equals(y)));
                            if ((disponibles.ContainsKey(item1)) == false)
                            {
                                disponibles.Add(item1, true);
                            }
                        }
                        else
                        {
                            if ((disponibles.ContainsKey(item1)) == false)
                            {
                                disponibles.Add(item1, false);
                            }
                        }
                    }
                }
                obj = new coleccion(data[0],missing, available, repeated);
                listados.Add(data[0], obj);
                contador++;
            }
            reader.Close();
        }       
    }
}
