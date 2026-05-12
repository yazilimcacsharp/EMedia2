using Microsoft.Build.Execution;

namespace EMedia.Models
{
    public class CreditCart
    {
        public int CreditCartId { get; set; }
        public string FullName { get; set; }
        public string CreditCartNumber { get; set; }
        public decimal Limit { get; set; }
        public string CVC { get; set; }
        public string ExpDate { get; set; }
    }
}
