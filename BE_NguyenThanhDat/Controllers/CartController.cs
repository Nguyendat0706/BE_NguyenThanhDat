using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BE_NguyenThanhDat.Models;

namespace BE_NguyenThanhDat.Controllers
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class CartController : Controller
    {
        private AppDbContext db = new AppDbContext();

        private List<CartItem> GetCart()
        {
            var cart = Session["CART"] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                Session["CART"] = cart;
            }
            return cart;
        }

        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public ActionResult Add(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();

            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.Product.ProductID == id);
            if (item == null)
            {
                cart.Add(new CartItem
                {
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.ProductID == id);
            if (item != null)
            {
                cart.Remove(item);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.ProductID == id);

            if (item != null)
            {
                if (quantity <= 0)
                    cart.Remove(item);
                else
                    item.Quantity = quantity;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Session["CART"] = null;
            return RedirectToAction("Index");
        }
    }
}
