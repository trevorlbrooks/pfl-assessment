using pfl_assessment.Models;
using pfl_assessment.Models.Json.Orders;
using pfl_assessment.Models.Json.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace pfl_assessment.Controllers
{
    public class CartController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Item>();
            }
            List<Item> cart = (List<Item>)Session["cart"];

            OrderPayload pricedOrder = null;
            if (cart.Count > 0 && Session["customer"] != null)
            {
                Customer customer = (Customer)Session["customer"];
                OrderPayload order = OrderApi.CreateOrderPayload(cart, customer);
                pricedOrder = await PriceApi.PriceOrder(order);
                ViewData["pricedOrder"] = pricedOrder;
            }
            ViewData["Customer"] = Session["customer"];
            return View(cart);
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(FormCollection form)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Item>();
            }
            if (form["productId"] != null && form["quantity"] != null)
            {
                Item itemToAdd = new Item
                {
                    ProductID = Convert.ToInt32(form["productId"]),
                    Quantity = Convert.ToInt32(form["quantity"]),
                    TemplateData = new List<TemplateData>()
                };
                if (form["imageURL"] != null)
                {
                    itemToAdd.ItemFile = new Uri(form["imageURL"]);
                }
                itemToAdd.Product = await ProductsApi.GetProduct(itemToAdd.ProductID);
                if (itemToAdd.Product != null)
                {
                    if (itemToAdd.Product.HasTemplate)
                    {
                        foreach (Field templateField in itemToAdd.Product.TemplateFields.Fieldlist.Field)
                        {
                            itemToAdd.TemplateData.Add(new TemplateData
                            {
                                TemplateDataName = templateField.Htmlfieldname,
                                TemplateDataValue = form[templateField.Htmlfieldname]
                            });
                        }
                    }
                    ((List<Item>)Session["cart"]).Add(itemToAdd);
                }
            }
            return await Task.FromResult(RedirectToAction("Index", "Cart"));
        }

        [HttpPost]
        public ActionResult RemoveItem(FormCollection form)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Item>();
            }
            int? index = Convert.ToInt32(form["index"]);
            if (index != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                if (cart.Count > index)
                {
                    cart.RemoveAt(index.Value);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(FormCollection form)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Item>();
            }
            int? index = Convert.ToInt32(form["index"]);
            int? quantity = Convert.ToInt32(form["quantity"]);
            if (index != null && quantity != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                if (cart.Count > index)
                {
                    cart[index.Value].Quantity = quantity.Value;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EmptyCart()
        {
            Session["cart"] = new List<Item>();
            return RedirectToAction("Index", "Store");
        }

        [HttpPost]
        public ActionResult UpdateAddress(FormCollection form)
        {
            Session["customer"] = new Customer
            {
                FirstName = form["firstName"],
                LastName = form["lastName"],
                CompanyName = form["companyName"],
                Address1 = form["address1"],
                Address2 = form["address2"],
                City = form["city"],
                State = form["state"],
                PostalCode = form["postalCode"],
                CountryCode = form["countryCode"],
                Email = form["email"],
                Phone = form["phone"]
            };
            return RedirectToAction("Index");
        }
    }
}
