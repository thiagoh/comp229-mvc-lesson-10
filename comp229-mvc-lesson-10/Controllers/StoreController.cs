using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp229_mvc_lesson_10.Models;

namespace comp229_mvc_lesson_10.Controllers {
    public class StoreController : Controller {
        private MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: Store
        public ActionResult Index() {

            var genres = new List<Genre>() {
                //new Genre("Classic"),
                //new Genre("Disco"),
                //new Genre("Eletronic"),
                //new Genre("Jazz"),
                //new Genre("Rock"),
            };

            //return View(genres);
            return View(db.Genres.ToList());
        }

        //// GET: Store/Details/5
        //public ActionResult Details(int? id) {
        //    if (id == null) {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Genre genre = db.Genres.Find(id);
        //    if (genre == null) {
        //        return HttpNotFound();
        //    }
        //    return View(genre);
        //}

        // GET: Store/Details/5
        public ActionResult Details(int? id) {

            var album = new Album("Album " + id);

            return View(album);
        }

        // GET: Store/Browse?genre=Disco
        public ActionResult Browse(string genre = "disco") {

            //name = string.IsNullOrEmpty(name) ? "disco" : name;

            //var genre = new Genre() {
            //    Name = name
            //};

            //return View(genre);
            genre = string.IsNullOrEmpty(genre) ? "disco" : genre;

            var genreObject = db.Genres.Include("Albums").Single<Genre>(g => g.Name == genre);

            return View(genreObject);
        }
    }
}
