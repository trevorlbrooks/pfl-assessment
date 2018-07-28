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
            ApiAccessor api = ApiAccessor.Singleton;
            List<Product> productList = await api.GetProducts();
            ViewBag.Message = productList.Count + "<br/>" + productList.ToString();
            //ViewBag.Message = await ApiAccessor.Singleton.GetProductsJson();
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
