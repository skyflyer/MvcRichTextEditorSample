using Redactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Redactor.Controllers
{
    public class ManageContentController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new NewsRepository()) {
                var contents = db.News.OrderByDescending(n => n.PublishedDate).Take(50).ToList();
                return View(contents);
            }
        }

        public ActionResult Show(int id)
        {
            using(var db = new NewsRepository())
            {
                return View(db.News.Single(n => n.Id == id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(NewsItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: save
            using (var db = new NewsRepository())
            {
                db.News.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("index");
            }
        }
    }
}