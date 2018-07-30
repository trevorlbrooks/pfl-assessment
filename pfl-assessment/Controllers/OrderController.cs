using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Success(string id)
        {
            if (!String.IsNullOrEmpty(id.Trim()))
            {
                OrderPayload order = await OrderApi.GetOrder(id);
                if (order != null)
                {
                    foreach (Item item in order.Items)
                    {
                        item.Product = await ProductsApi.GetProduct(item.ProductID);
                    }
                    return View(order);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Place()
        {
            if (Session["cart"] != null && Session["customer"] != null)
            {
                if (Session["cart"] is List<Item> && Session["customer"] is Customer)
                {
                    List<Item> items = (List<Item>)Session["cart"];
                    Customer customer = (Customer)Session["customer"];

                    OrderPayload order = OrderApi.CreateOrderPayload(items, customer);
                    order = await OrderApi.PlaceOrder(order);
                    //Clear cart
                    Session["cart"] = new List<Item>();
                    return RedirectToAction("Success", "Order", new { @id = order.OrderNumber });
                }
            }
            return RedirectToAction("Index");
        }
    }
}