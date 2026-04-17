using Microsoft.AspNetCore.Components.Web;

namespace EMedia.Models
{
    public class Product
    {
        //id,ad,altkategoriid,isActive,fiyat,eklenmetarihi,stokadet
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public bool IsActive { get; set; }
       
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Stock { get; set; }
        public string FotoPath { get; set; }

        //propfull : get-set içeren kısımları yazdırdı
        //private int yas;

        //public int Yas
        //{
        //    get { return yas; }
        //    set
        //    {
        //        if (value > 0 && value < 120)
        //            yas = value;
        //        else
        //            yas = -999;
        //    }
        //}

        public int? DiscountRate { get; set; } //int : int?(boş geçilebilir null olabilir)

        public ICollection<ProductComment> ProductComments { get; set; }


    }
}
