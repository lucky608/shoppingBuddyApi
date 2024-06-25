using Microsoft.EntityFrameworkCore;

namespace KisaanCafeWebAPI.ViewModels
{
    public class ProductInInvoice
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }
        public decimal Weight { get; set; }
        public decimal totalWeight { get; set; }
        public decimal TotalPrize { get; set; }
    }
}
