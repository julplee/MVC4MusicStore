namespace MvcMusicStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MvcMusicStore.Models;

    public class StoreController : Controller
    {
        private MusicStoreEntities storeDb = new MusicStoreEntities();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDb.Genres.ToList();
            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=disco
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDb.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var genre = new Genre { Name= "Genre " + id };
            return View(genre);
        }
    }
}
