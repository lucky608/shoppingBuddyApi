using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Repository.Product
{
    public interface IProductRepository
    {
        Task<List<ProductDetails>> GetAllProductAsync();
        Task<List<InvoiceDetails>> GetAllInvoiceAsync(string role);
        Task<List<UserCommand>> GetAllUsersAsync(string role);
        Task<UserCommand> DeleteUserByIdAsync(string role, string phoneNumber);
        Task<UserCommand> GetUserByPhPassAsync(string phone,string password);
        Task<List<InvoiceDetails>> GetInvoiceAsync(string mobileNumber);
        Task<ProductCommand> AddProductAsync(ProductCommand product);
        Task<UserCommand> AddUserAsync(UserCommand user);
        Task<InvoiceDetails> AddCustomerDetailsAsync(InvoiceDetails invoiceDetails);
        Task<bool> DeleteProductAsync(int productId);
        Task<bool> DeleteInvoiceAsync(int invoiceId, string role);
        Task<bool> UpdateProductAsync(int productId,ProductCommand product);
        Task<bool> UpdateInvoiceAsync(int invoiceId, InvoiceDetails invoice, string role);

    }
}
