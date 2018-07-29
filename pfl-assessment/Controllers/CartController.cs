using pfl_assessment.Models;
using pfl_assessment.Models.Json.Orders;
using pfl_assessment.Models.Json.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                    ProductID = System.Convert.ToInt32(form["productId"]),
                    Quantity = System.Convert.ToInt32(form["quantity"]),
                    TemplateData = new List<TemplateData>()
                };
                itemToAdd.Product = await ProductsApi.GetProduct(itemToAdd.ProductID);
                if (itemToAdd.Product != null)
                {
                    if (itemToAdd.Product.HasTemplate)
                    {
                        foreach (Field templateField in itemToAdd.Product.TemplateFields.Fieldlist.Field)
                        {
                            itemToAdd.TemplateData.Add(new TemplateData
                            {
                                TemplateDataName = templateField.Fieldname,
                                TemplateDataValue = form[templateField.Fieldname]
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
            int? index = System.Convert.ToInt32(form["index"]);
            if (index != null) {
                List<Item> cart = (List<Item>)Session["cart"];
                if (cart.Count > index) {
                    cart.RemoveAt(index.Value);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(FormCollection form) {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Item>();
            }
            int? index = System.Convert.ToInt32(form["index"]);
            int? quantity = System.Convert.ToInt32(form["quantity"]);
            if (index != null && quantity != null) {
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
    }
}
