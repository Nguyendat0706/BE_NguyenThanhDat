using System.Linq;
using System.Web.Mvc;
using BE_NguyenThanhDat.Models;
using System.Data.Entity;

namespace BE_NguyenThanhDat.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // HOME PAGE
        public ActionResult Index(string search, int page = 1, int pageSize = 8)
        {
            IQueryable<Product> query = db.Products.Include("Category");

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.ProductName.Contains(search));

            int totalItems = query.Count();

            var data = query
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Search = search;
            ViewBag.Page = page;
            ViewBag.TotalItems = totalItems;
            ViewBag.PageSize = pageSize;

            return View(data);
        }

        // CHI TIẾT
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            var product = db.Products
                .Include("Category")
                .FirstOrDefault(p
