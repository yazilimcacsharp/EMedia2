namespace EMedia.Helper
{
    public class MyHelper
    {
        //random ile 17 tane 10-70 aralıgında indirim oranı üret ve tabloya yazacak c# kodunu yaz


        public List<int> RandomGenerateForProducts(int kayitSayisi)
        {
            List<int> discountRates = new List<int>();
            Random rastgele = new Random();
            for (int i = 0; i < kayitSayisi; i++)
            {
                discountRates.Add(rastgele.Next(10, 71));
            }
            return discountRates;
        }

    }
}
