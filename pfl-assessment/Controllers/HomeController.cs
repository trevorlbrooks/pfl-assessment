using System.Collections.Generic;
using System.Web.Mvc;

using pfl_assessment.Models.Json.Orders;

namespace pfl_assessment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["cart"] = new List<Item>();
            ((List<Item>)Session["cart"]).Add(new Item());
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}
