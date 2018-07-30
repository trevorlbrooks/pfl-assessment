using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pfl_assessment.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lookup(int? id)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Place()
        {

            return RedirectToAction("Index");
        }
    }
}