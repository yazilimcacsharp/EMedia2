using EMedia.Data;
using EMedia.Models;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArtDBContext _artDBContext;

        public HomeController(ILogger<HomeController> logger,ArtDBContext artDBContext)
        {
            _logger = logger;
            _artDBContext = artDBContext;
        }

        public IActionResult Index()
        {

            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalý",
                MenuItems = _artDBContext.Categories.Where(satir=>satir.IsActive==true).Select(satir => satir.Name).ToList()
            };

            string adetSession = HttpContext.Session.GetString("adet") ?? "0";
            HttpContext.Session.SetString("adet", adetSession);
           
            Response.Cookies.Append("adet", adetSession);

            // Bu request içinde güncel deðeri buradan alýn
            string adetStr = adetSession;



            layoutModel.SepetAdet=string.IsNullOrEmpty(adetStr) ?0 : Convert.ToInt32(adetStr);

            ViewBag.LayoutModel = layoutModel;


            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
