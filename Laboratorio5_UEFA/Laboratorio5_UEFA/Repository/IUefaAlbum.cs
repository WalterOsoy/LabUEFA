using System;
using Laboratorio5_UEFA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5_UEFA.Repository
{
    public interface IUefaAlbum
    {
        List<Estampa> ListadoTipo(string valor, int i);
        void LlenarListados();
        coleccion GetTeam(string id);
        List<coleccion> getAlbumTeams();
    }
}
