using EMedia.Data;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EMedia.Controllers
{
    public class CartController : Controller
    {
        private readonly ArtDBContext _artDBContext;

        public CartController(ArtDBContext artDBContext)
        {
            _artDBContext = artDBContext;
        }
        public IActionResult Index()
        {
            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalı",
                MenuItems = _artDBContext.Categories.Where(satir => satir.IsActive == true).Select(satir => satir.Name).ToList()
            };

            ViewBag.LayoutModel = layoutModel;

            return View();
        }
    }
}
