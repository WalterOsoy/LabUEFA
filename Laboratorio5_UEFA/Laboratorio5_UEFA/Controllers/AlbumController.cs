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
        readonly IUefaAlbum card;
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SubirArchivo()
        {
            card.LoadAlbum();
            card.loadAdquiridas();
            return RedirectToAction(nameof(Index));
        }
    }
}