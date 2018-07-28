using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using pfl_assessment.Models;
using pfl_assessment.Models.Json.Products;

namespace pfl_assessment.Controllers
{
    public class StoreController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Product> products = await ProductsApi.GetProducts();
            ViewData["products"] = products;
            return View();
        }
    }
}
