using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using pfl_assessment.Models;
using pfl_assessment.Models.Products;

namespace pfl_assessment.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Product> productList = await ProductsApi.GetProducts();
            ViewBag.Message = productList.Count + "<br/>" + productList.ToString();
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
