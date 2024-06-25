using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Services.Product
{
    public interface IProductServices
    {
        Task<List<ProductDetails>> GetProductDetailsAsync();
        Task<List<InvoiceDetails>> GetAllInvoiceAsync(string role);
        Task<List<UserCommand>> GetAllUsersAsync(string role);
        Task<UserCommand> DeleteUserByIdAsync(string role, string phoneNumber);
        Task<UserCommand> GetUserByPhPassAsync(string phone, string password);
        Task<PostActionModel> AddProductAsync(ProductCommand product);
        Task<PostUserAction> AddUserAsync(UserCommand user);
        Task<PostInvoiceDetails> AddCustomerDetailsAsync(InvoiceDetails invoiceDetails);
        Task<List<InvoiceDetails>> GetInvoiceAsync(string mobileNumber);
        Task<DeleteActionCode> DeleteProductAsync(int productId);

        Task<DeleteActionCode> DeleteInvoiceAsync(int invoiceId,string role);
        Task<PutActionResult> UpdateProductAsync(int  productId, ProductCommand product);
        Task<PutActionResult> UpdateInvoiceAsync(int invoiceId, InvoiceDetails invoice,string role);
    }
}
