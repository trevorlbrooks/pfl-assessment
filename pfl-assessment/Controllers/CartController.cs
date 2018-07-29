using pfl_assessment.Models.Json.Orders;
using System.Collections.Generic;
using System.Web.Mvc;

namespace pfl_assessment.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem()
        {
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public ActionResult RemoveItem()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EmptyCart()
        {
            Session["cart"] = new List<Item>();
            return RedirectToAction("Index", "Store");
        }
    }
}
