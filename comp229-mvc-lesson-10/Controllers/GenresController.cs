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
    public class GenresController : Controller {
        private MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: Genres
        public ActionResult Index() {
            return View(db.Genres.ToList());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null) {
                return HttpNotFound();
            }
            return View(genre);
        }
    }
}
