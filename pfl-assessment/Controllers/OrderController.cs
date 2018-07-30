using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using pfl_assessment.Models;
using pfl_assessment.Models.Json.Orders;

namespace pfl_assessment.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Lookup(int? id)
        {
            if (id != null)
            {
                OrderPayload order = await OrderApi.GetOrder(id.Value);
                if (order != null)
                {
                    return View(order);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Place()
        {

            return RedirectToAction("Index");
        }
    }
}