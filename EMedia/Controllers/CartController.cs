using EMedia.Data;
using EMedia.Models;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMedia.Controllers
{
    public class CartController : Controller
    {
        private readonly ArtDBContext _artDBContext;
        private ShoppingCart shoppingCart;

        public CartController(ArtDBContext artDBContext)
        {
            _artDBContext = artDBContext;
            shoppingCart= new ShoppingCart();
            shoppingCart._context = artDBContext;
        }

        public IActionResult Index()
        {
            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalı",
                MenuItems = _artDBContext.Categories.Where(satir => satir.IsActive == true).Select(satir => satir.Name).ToList()
            };

            string adetStr = Request.Cookies["adet"];
            layoutModel.SepetAdet = string.IsNullOrEmpty(adetStr) ? 0 : Convert.ToInt32(adetStr);




            var cart =shoppingCart.GetCart(HttpContext);

            var viewModel = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };


            ViewData["CartCount"] = adetStr;
            layoutModel.SepetAdet = Convert.ToInt32(HttpContext.Session.GetString("adet"));

            ViewBag.LayoutModel = layoutModel;

            return View(viewModel);
        }


        public IActionResult AddToCart(int id,int sepetAdet) //hangi ürünü sepete eklemişseniz o ürünün id bilgisini bize verir.
        {
            var eklenecekUrun = _artDBContext.Products.FirstOrDefault(satir => satir.Id == id);
            var cart=shoppingCart.GetCart(HttpContext);
            cart.AddToCart(eklenecekUrun,sepetAdet);
            HttpContext.Session.SetString("adet", cart.GetCount().ToString());

            //Cookie tarafına ekleme işlemi
            Response.Cookies.Append("adet", cart.GetCount().ToString());

            return RedirectToAction("Index");
        }

        //sepet detay içerisindeki bilgiyi göstermek için eklenecek metot

        public PartialViewResult CartSummary()
        {
            var cart=shoppingCart.GetCart(HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        //sepetten ürün silme
        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart=shoppingCart.GetCart(HttpContext);

            var productName=_artDBContext.Carts.Include(satir => satir.Product).FirstOrDefault(satir => satir.RecordId == id).Product.Name;

            int itemCount = cart.RemoveFromCart(id); //silme işlemi sonrasında sepette geriye kalan ürünleriin ürün adedini bulur.
            HttpContext.Session.SetString("adet", cart.GetCount().ToString()); //güncel ürün adet bilgisini sessiondaki adet key değerine atar.


            Response.Cookies.Append("adet", cart.GetCount().ToString());

            var result = new ShoppingCartRemoveViewModel()
            {
                Message = productName + " ürününü silmek istediğine emin misin?",
                cartTotal = cart.GetTotal(),
                cartCount = cart.GetCount(),
                itemCount = itemCount,
                deleteId = id
            };

            return Json(result);
        }


        public IActionResult EmptyCart() 
        {
            var cart = shoppingCart.GetCart(HttpContext);
            cart.EmptyCart();
            HttpContext.Session.SetString("adet", "0");

            //Cookie tarafına ekleme işlemi
            Response.Cookies.Append("adet", "0");

            return RedirectToAction("Index");
        }


    }
}
