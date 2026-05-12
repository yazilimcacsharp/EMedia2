using EMedia.Data;
using EMedia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMedia.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ArtDBContext _artDBContext;
        const string PromoCode = "FREE";
        private ShoppingCart shoppingCart;

        public CheckoutController(ArtDBContext context)
        {
            _artDBContext = context;
            shoppingCart = new ShoppingCart();
            shoppingCart._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddressAndPayment()
        {
            return RedirectToAction("Index","Cart");
        }

        [HttpPost]
        public IActionResult AddressAndPayment(IFormCollection values)
        {
            var Order = new Order();
            string adres = values["Address"];


            if (!string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                return View(Order);

            else
            {
                Order.UserName = User.Identity.Name;
                Order.FirstName = values["FirstName"];
                Order.LastName = values["LastName"];
                Order.OrderDate = DateTime.Now;
                Order.City = values["City"];
                Order.Email = values["Email"];
                Order.Country = values["Country"];
                Order.Phone = values["Phone"];
                Order.State = values["State"].ToString() ?? "1";

                Order.PostalCode = values["PostalCode"];
                Order.Total = Convert.ToDecimal(values["Total"]);
                HttpContext.Session.SetString("toplamTutar", Order.Total.ToString());
                _artDBContext.Orders.Add(Order);
                _artDBContext.SaveChanges();

                var cart = shoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(Order);

                ViewData["CartCount"] = cart.GetCount();


                return RedirectToAction("Complete", new { id = Order.OrderId });
            }
        }

        public IActionResult Complete()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Complete(string cartNo,string name,string expdate,string cvc)
        {
            string tutar=HttpContext.Session.GetString("toplamTutar");
            var kayit=_artDBContext.CreditCarts.Where(satir => satir.CreditCartNumber == cartNo && satir.FullName == name && satir.CVC == cvc && satir.ExpDate == expdate && satir.Limit > int.Parse(tutar)).FirstOrDefault();

            if (kayit != null)
            {
                //işlem başarılı.
            }
            else
            {
                //bilgiler yanlış
            }
            return View();
        }

    }
}
