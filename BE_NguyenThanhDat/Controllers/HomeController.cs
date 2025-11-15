using System.Linq;
using System.Web.Mvc;
using BE_NguyenThanhDat.Models;
using System.Data.Entity;

namespace BE_NguyenThanhDat.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            // Lấy 8 sản phẩm mới nhất
            var products = db.Products
                             .Include("Category")
                             .OrderByDescending(p => p.ProductID)
                             .Take(8)
                             .ToList();

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
