using EMedia.Data;
using EMedia.Helper;
using EMedia.Migrations;
using EMedia.Models;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ProductComment = EMedia.Models.ProductComment;

namespace EMedia.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ArtDBContext _artDBContext;
        private readonly ApplicationDbContext applicationDbContext;
        public ProductsController(ArtDBContext artDBContext, ApplicationDbContext applicationDbContext)
        {
            _artDBContext = artDBContext;
            this.applicationDbContext = applicationDbContext; //this: bu class demek
            //eğer tanımlama satırındaki adı ile ctor içerisindeki parametre adı aynıysa this kullan
        }
        public IActionResult Index()
        {
            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalı",
                MenuItems = _artDBContext.Categories.Where(satir => satir.IsActive == true).Select(satir => satir.Name).ToList()
            };

            ViewBag.LayoutModel = layoutModel;

            //int kayitAdedi=_artDBContext.Products.Count(); //select count(*)

            //MyHelper helper = new MyHelper();

            //List<int> indirimOranlari=helper.RandomGenerateForProducts(kayitAdedi);

            //int sayac = 0;
            //foreach (var item in _artDBContext.Products)
            //{
            //    item.DiscountRate = indirimOranlari[sayac];
            //    sayac++;
            //}
            //_artDBContext.SaveChanges();



            //var liste = _artDBContext.Products.Where(satir=>satir.IsActive==true).Include("SubCategory").ToList();
            var liste = _artDBContext.Products.Include("SubCategory").ToList();
            return View(liste);
        }


        public IActionResult Details(int id)
        {

            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalı",
                MenuItems = _artDBContext.Categories.Where(satir => satir.IsActive == true).Select(satir => satir.Name).ToList()
            };

            ViewBag.LayoutModel = layoutModel;


            //Product product= _artDBContext.Products.FirstOrDefault(satir => satir.Id == id);
            Product? product = _artDBContext.Products
    .Include(p => p.ProductComments)
        .ThenInclude(pc => pc.Comment)
    .FirstOrDefault(p => p.Id == id);
            string fotopath = product.FotoPath;
            product.FotoPath = "/";
            product.FotoPath += fotopath;

            ViewBag.Adet = _artDBContext.ProductComments.Where(satir => satir.ProductId == id && satir.IsApproved == 1).Count();

            //select avg(point),ProductId
            //from ProductComments where IsApproved = 1 group by ProductId


            ViewBag.PuanOrtalama = (_artDBContext.ProductComments
        .Where(x => x.IsApproved == 1 && x.ProductId == id)
        .Average(x => (decimal?)x.Point) ?? 0).ToString("0.#");



            //urun bazında kaç kişi 5 yıldız, kaç kişi 4 yıldız vermiş,3,2,1 gibi bilgileri de viewbag ile gönderebiliriz.

            var ratingCounts = _artDBContext.ProductComments
    .Where(x => x.IsApproved == 1 && x.ProductId == id)
    .GroupBy(x => x.Point)
    .Select(g => new
    {
        Point = g.Key,
        Count = g.Count()
    })
    .ToList();

            // ViewBag'e tek tek atayalım (1-5 arası garanti olsun)
            ViewBag.Puan5 = ratingCounts.FirstOrDefault(x => x.Point == 5)?.Count ?? 0;
            ViewBag.Puan4 = ratingCounts.FirstOrDefault(x => x.Point == 4)?.Count ?? 0;
            ViewBag.Puan3 = ratingCounts.FirstOrDefault(x => x.Point == 3)?.Count ?? 0;
            ViewBag.Puan2 = ratingCounts.FirstOrDefault(x => x.Point == 2)?.Count ?? 0;
            ViewBag.Puan1 = ratingCounts.FirstOrDefault(x => x.Point == 1)?.Count ?? 0;


            var users=_artDBContext.ProductComments.Where(satir => satir.ProductId == id && satir.IsApproved == 1).ToList();

            foreach (var item in users)
            {
                ViewBag.Email = applicationDbContext.Users.Where(satir => satir.Id == item.UserId).FirstOrDefault().Email;
            }
         





                


            return View(product);

        }


        [HttpPost]
        public IActionResult YorumYap(string productid, string yorum, string rating)
        {
            //1.yorumu yorum tablosuna ekleyelim.
            //2.o son yorumun id bilgisini alalım.
            //3.productComments tablosuna parametre gelen productid'ye 2.aşamada buldugunuz yorumid kaydedelim.
            //_artDBContext.Comments.Add(yorum);
            //_artDBContext.SaveChanges();

            Comment comment = new Comment();
            comment.Text = yorum;

            _artDBContext.Comments.Add(comment);

            _artDBContext.SaveChanges();

            //1.yol
            //int yorumid=_artDBContext.Comments.Where(satir => satir.Text == yorum).FirstOrDefault().CommentId;

            //2.yol
            //int yorumid2=_artDBContext.Comments.FirstOrDefault(satir => satir.Text == yorum).CommentId;



            ProductComment productComment = new ProductComment();
            productComment.ProductId = Convert.ToInt32(productid);
            productComment.CommentId = comment.CommentId; //3.yol
            //productComment.IsActive = false;
            productComment.Point = int.Parse(rating);
            productComment.IsApproved = 0;
            productComment.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            string? username = User.Identity?.Name;
            productComment.UserId = applicationDbContext.Users.Where(satir => satir.UserName == username).FirstOrDefault().Id;
            _artDBContext.ProductComments.Add(productComment);
            _artDBContext.SaveChanges();


            //return RedirectToAction("Details", "Products", productid);

            return RedirectToAction("Details", "Products", new { id = productid });


        }


    }
}
