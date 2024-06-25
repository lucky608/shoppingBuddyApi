using Microsoft.EntityFrameworkCore;

namespace KisaanCafeWebAPI.ViewModels
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string fullAddress { get; set; }
        public string paymentMode { get; set; }
        public string phoneNumber { get; set; }
        public long totalAmount { get; set; }
        public long ammountPaid { get; set; }
        public long amountLeft { get; set; }
        public ProductInInvoice productDetails { get; set; }
    }
}
