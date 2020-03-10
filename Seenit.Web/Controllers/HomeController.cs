using Seenit.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seenit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostData db;

        public HomeController(IPostData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Seenit is a posting engine";

            return View();
        }

        [HttpGet]
        public ActionResult PostDetails(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }



    }
}