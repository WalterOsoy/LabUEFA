using Laboratorio5_UEFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Repository
{
    public class UefaAlbum: IUefaAlbum
    {
        public static string ubicacion1 = @"C:\Users\DISTELSA\Desktop\album.csv";
        public static string ubicacion2 = @"C:\Users\DISTELSA\Desktop\calcomanias.csv";
        public static Dictionary<string, album> album = new Dictionary<string, album>();
        public static Dictionary<string, coleccion> adquirido = new Dictionary<string, coleccion>();
        public static Dictionary<estampa, bool> estado = new Dictionary<estampa, bool>();
        public  void LoadAlbum()
        {
            album obj = new album();
            System.IO.StreamReader reader = new System.IO.StreamReader(ubicacion1);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                line.ToLower();
                string[] data = line.Split(",");
                obj.tipo = data[0];
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] != "")
                    {
                        obj.insertarNumero(Convert.ToInt32(data[i]));
                    }
                }
                album.Add(obj.tipo, obj);
                obj = new album();
            }
            reader.Close();
        }
        public void LoadAdquiridas()
        {
            coleccion obj = new coleccion();
            System.IO.StreamReader reader = new System.IO.StreamReader(ubicacion2);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                line.ToLower();
                string[] data = line.Split(",");
                obj.tipo = data[0];
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] != "")
                    {
                        obj.insetaradquisicion(Convert.ToInt32(data[i]));
                    }
                }
                adquirido.Add(obj.tipo, obj);
                obj = new coleccion();
            }
            reader.Close();
        }
    }
}
