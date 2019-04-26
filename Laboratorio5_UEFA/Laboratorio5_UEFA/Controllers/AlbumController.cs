using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio5_UEFA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio5_UEFA.Controllers
{
    public class AlbumController : Controller
    {
        readonly IUefaAlbum Album;
        public AlbumController(IUefaAlbum A)
        {
            this.Album = A;
        }        
        public ActionResult Index()
        {
            return View(Album.getAlbumTeams());
        }
        public ActionResult SubirArchivo()
        {
            Album.LlenarListados();            
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(string id)
        {
            return View(Album.GetTeam(id));
        }
        public ActionResult LoadStampsFile(int No, string Team)
        {
            Album.LlenarListados();
            return RedirectToAction(nameof(Index));
        }
    }
}