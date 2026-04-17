using EMedia.Data;
using EMedia.Models;
using EMedia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EMedia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ArtDBContext _artDBContext;
        private readonly ApplicationDbContext _applicationDbContext;
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ArtDBContext artDBContext, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _artDBContext = artDBContext;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        //MVCde View tarafını açmak için alttaki metodu yazdık
        public IActionResult UserEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserEkle(string UserName, string Password)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = UserName;
            user.Email = UserName;
            user.NormalizedEmail = UserName.ToUpper();
            user.EmailConfirmed = true;
            await _userManager.CreateAsync(user, Password);

            return RedirectToAction("Index", "Admin");
        }

        //RolEkle metodu
        //Ekrana gösterilecek html kodunu geriye döndüren
        public IActionResult RolEkle()
        {
            return View();
        }


        //html sayfada girilen verileri alır, AspnetRoles tablosuna ekler.
        [HttpPost]
        public async Task<IActionResult> RolEkle(string rolName)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = rolName;
            identityRole.NormalizedName = rolName.ToUpper();
            identityRole.ConcurrencyStamp = rolName.ToUpper();
            try
            {
                var req = await _roleManager.CreateAsync(identityRole);

            }
            catch (Exception ex)
            {
                Exception exx = ex.InnerException;

            }
            return View();
        }

        //UyeyeRolAtama
        //Uyeler
        //Roller
        //uyeseçildi ,rol seçildi buttona basınca AspnetUserRoles tablosuna seçimleri kaydedelim.
        public IActionResult RolAta()
        {
            ViewBag.Users = _userManager.Users.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }


        /*

        [HttpPost]
        public async Task<IActionResult> KullaniciyaRolAta(string roleName, string userId)
        {
            //mailden id bul.
            var user = await _userManager.FindByEmailAsync(userId);
            if (user != null)
            {
                try
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                //User bulunamadı...
            }
            return RedirectToAction("Index", "Admin");
        }
        */

        [HttpPost]
        public async Task<IActionResult> RolAta(string RoleName, string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("RolAta");
            }

            if (await _userManager.IsInRoleAsync(user, RoleName))
            {
                TempData["Error"] = "Kullanıcı zaten bu role sahip.";
                return RedirectToAction("RolAta");
            }
            var result = await _userManager.AddToRoleAsync(user, RoleName);

            if (result.Succeeded)
            {
                TempData["Success"] = "Rol başarıyla atandı.";
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                TempData["Error"] = $"Hata oluştu: {errors}";
            }

            return RedirectToAction("RolAta");
        }


        public IActionResult UrunYorumOnayla()
        {
            //var liste= _artDBContext.ProductComments.Include().Where(satir => satir.IsActive == false).ToList();

            var liste = _artDBContext.ProductComments.Include(p => p.Product).Where(satir => satir.IsApproved == 0).Include(p => p.Comment).ToList();
            foreach (var item in liste)
            {
                item.UserId = _applicationDbContext.Users.Where(satir => satir.Id == item.UserId).FirstOrDefault().Email;
            }
            return View(liste);
        }

        [HttpPost]
        public IActionResult UrunYorumOnayla(int commentId)
        {
            var data= _artDBContext.ProductComments.FirstOrDefault(satir => satir.Id ==commentId);
            data.IsApproved = 1; //onaylananlar 1 olacak
            //data.IsActive = true;
            _artDBContext.ProductComments.Update(data);
            _artDBContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult UrunYorumRed(int commentId)
        {
            var data = _artDBContext.ProductComments.FirstOrDefault(satir => satir.Id == commentId);
            data.IsApproved = 2;
            //data.IsActive = false;
            _artDBContext.ProductComments.Update(data);
            _artDBContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        
        public IActionResult UrunEkle()
        {
            var layoutModel = new LayoutViewModel
            {
                SiteTitle = "Kültür Sanat Portalı",
                MenuItems = _artDBContext.Categories.Where(satir => satir.IsActive == true).Select(satir => satir.Name).ToList()
            };

            ViewBag.LayoutModel = layoutModel;


            ViewBag.SubCategories = new SelectList(_artDBContext.SubCategories, "Id", "Name");

            return View();
        }



        [HttpPost]
        public IActionResult UrunEkle(Product product, IFormFile foto)
        {
         
            if (foto != null && foto.Length > 0)
            {
            
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    foto.CopyTo(stream);
                }

                product.FotoPath = "/images/" + uniqueName;
            }

            product.CreatedDate = DateTime.Now; 

      
            _artDBContext.Products.Add(product);
            _artDBContext.SaveChanges();

            return RedirectToAction("Index"); 

        }

        [HttpPost]
        public IActionResult TopluOnay()
        {
            List<ProductComment> liste =_artDBContext.ProductComments.Where(satir => satir.IsApproved == 0).ToList();

            //Concurrency : birden fazla kişi aynı işlemi yapıyor demek
            foreach (var item in liste)
            {
                item.IsApproved = 1;
            }
            return RedirectToAction("Index");
        }


    }
}
