using EMedia.Data;
using EMedia.Models;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            ViewBag.LayoutModel = layoutModel;


            var cart=shoppingCart.GetCart(HttpContext);

            var viewModel = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };


            ViewData["CartCount"] = HttpContext.Session.GetString("adet");

            return View(viewModel);
        }


        public IActionResult AddToCart(int id) //hangi ürünü sepete eklemişseniz o ürünün id bilgisini bize verir.
        {
            var eklenecekUrun = _artDBContext.Products.FirstOrDefault(satir => satir.Id == id);
            var cart=shoppingCart.GetCart(HttpContext);
            cart.AddToCart(eklenecekUrun);
            HttpContext.Session.SetString("adet", cart.GetCount().ToString());

            return RedirectToAction("Index");
        }

        //sepet detay içerisindeki bilgiyi göstermek için eklenecek metot
        //sepetten ürün silme


    }
}
