using EMedia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMedia.Models
{
    public class ShoppingCart
    {
        //artDBContext

        public ArtDBContext _context { get; set; }

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId"; //const: sabitdğer pi sayisi gibi.


        //GetCart(): sepetteki ürünleri getirecek
        public List<Cart> GetCartItems()
        {
            return _context.Carts.Include("Product").Where(satir => satir.CartId == ShoppingCartId).ToList();
        }


        //kişi login durumda ise mailini, login değilse bize sistem tarafından atanmış olan Guid(global Unique Identifier) bilgisini dönecek metot
        private string GetCartId(HttpContext context)
        {
            if(context.Session.GetString("CartSessionKey")==null)
            {
                if (!String.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString("CartSessionKey", context.User.Identity.Name);
                }
                else
                {
                    context.Session.SetString("CartSessionKey",Guid.NewGuid().ToString());
                    
                    
                    //alttaki ipadresi cihaz bilgisi
                    //var ipAddress = context.Connection.RemoteIpAddress?.ToString();
                    //var userAgent = context.Request.Headers["User-Agent"].ToString();

                    //var deviceKey = $"{ipAddress}_{userAgent}";
                    //context.Session.SetString("CartSessionKey", deviceKey);

                    
                }
            }
            return context.Session.GetString("CartSessionKey");
        }


        public ShoppingCart GetCart(HttpContext httpContext)
        {
            ShoppingCart cart = new ShoppingCart();
            cart._context = _context;
            cart.ShoppingCartId = cart.GetCartId(httpContext);
            return cart;
        }

        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        //sepete ürün ekle
        public void AddToCart(Product product)
        {
            var cartItem = _context.Carts.FirstOrDefault(satir => satir.CartId == ShoppingCartId && satir.ProductId == product.Id);

            if (cartItem == null)
            {
                //SEPETE YENİ EKLENEN BİR ÜRÜN
                cartItem = new Cart
                {
                    ProductId = product.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                _context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            _context.SaveChanges();
        }


        //sepetten ürün sil
        public int RemoveFromCart(int id)
        {
            var item= _context.Carts.First(satir => satir.CartId == ShoppingCartId && satir.RecordId == id);

            int itemCount = 0;

            if (item != null)
            {
                if(item.Count>1)
                {
                    item.Count--;
                    itemCount = item.Count;
                }
                else
                {
                    _context.Carts.Remove(item);
                }
                _context.SaveChanges();
            }
            return itemCount;
        }

        //sepeti boşalt metodu
        public void EmptyCart()
        {
            var sepettekiUrunler=_context.Carts.Where(satir => satir.CartId == ShoppingCartId);

            foreach (var item in sepettekiUrunler)
            {
                _context.Carts.Remove(item);
            }
            _context.SaveChanges();
        }


        //sepetteki ürün adedi
        public int GetCount()
        {
            int? count = _context.Carts.Where(satir => satir.CartId == ShoppingCartId).Select(satir => satir.Count).Sum();
            return count ?? 0; 
        }


        //sepetteki ürünleri toplam tutar bilgisi
        public decimal GetTotal()
        {
            decimal? total=_context.Carts.Where(satir => satir.CartId == ShoppingCartId).Select(satir => satir.Count*satir.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        //migrateCart ( login olmayan kişinin yaptığı alışverişleri login olunca o kişiye aktarma ,taşıma işlemi

        public void MigrateCart(string Username)
        {
            var items=_context.Carts.Where(satir => satir.CartId == ShoppingCartId);

            foreach (var item in items)
            {
                item.CartId = Username;
            }
            _context.SaveChanges();
        }


        //ziraat bankası dokuman sitesi
        //https://vpos.ziraatpay.com.tr/ziraatpay/api/v2/doc

        //yeni sipariş oluşturma
        //Order - Order Detail


        //yeni siparişi oluşturur, siparişi bilgilerini order details tablosuna ekler, toplam tutarı hesaplar, bize geriye sipariş no bilgisi dönecek metot
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var items = GetCartItems();


            foreach (var item in items)
            {
                var OrderDetail = new OrderDetail()
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);

                if (order.Country == "USA" || order.Country == "America")
                    order.Fee = 0.23m;
                else if (order.Country == "Turkey" || order.Country == "Türkiye")
                    order.Fee = 0.18m;
                else
                    order.Fee = 0.10m;
                _context.OrderDetails.Add(OrderDetail);

            }


            order.Total = orderTotal;

            _context.SaveChanges();

            return order.OrderId;
        }











    }
}
