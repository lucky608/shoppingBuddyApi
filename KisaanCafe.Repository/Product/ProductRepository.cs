using KisaanCafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Repository.Product
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetails>> GetAllProductAsync()
        {
            try
            {
                var listFromDb = await _context.ProductDetails
                    .Select(x => new ProductDetails
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Prize = x.Prize,
                        size=x.size,
                        ImageData = x.ImageData
                        
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);

                return listFromDb;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }

        public async Task<List<UserCommand>> GetAllUsersAsync(string role)
        {
            try
            {
                if (role == "adminJitu")
                {
                    var listFromDb = await _context.userDetails
                        .Select(x => new UserCommand
                        {
                            Id = x.Id,
                            phoneNumber = x.phoneNumber,
                            password = x.password

                        })
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return listFromDb;
                }
                return new List<UserCommand>();
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }

        public async Task<List<InvoiceDetails>> GetAllInvoiceAsync(string role)
        {
            try
            {
                if (role == "adminJitu")
                {
                    var listFromDb = await _context.InvoiceDetails
                        .Select(x => new InvoiceDetails
                        {
                            Id = x.Id,
                            fullName = x.fullName,
                            fullAddress = x.fullAddress,
                            totalAmount = x.totalAmount,
                            phoneNumber = x.phoneNumber,
                            paymentMode = x.paymentMode,
                            status=x.status

                        })
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return listFromDb;
                }
                return new List<InvoiceDetails>();
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }

        public async Task<UserCommand> GetUserByPhPassAsync(string phone, string password)
        {
            try
            {
                var userFromDb = await _context.userDetails
                    .Where(x => x.phoneNumber == phone && x.password == password)
                    .Select(x => new UserCommand
                    {
                        Id = x.Id,
                        phoneNumber = x.phoneNumber,
                        password = x.password
                    })
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

                return userFromDb;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }


        public async Task<List<InvoiceDetails>> GetInvoiceAsync(string mobileNumber)
        {
            try
            {
                var listFromDb = await _context.InvoiceDetails
                    .Where(x => x.phoneNumber == mobileNumber)
                    .Select(x => new InvoiceDetails
                    {
                        Id = x.Id,
                        fullName = x.fullName,
                        fullAddress= x.fullAddress,
                        totalAmount = x.totalAmount,
                        phoneNumber= x.phoneNumber,
                        paymentMode = x.paymentMode,
                        status=x.status

                    })
                    .ToListAsync()
                    .ConfigureAwait(false);

                return listFromDb;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }

        public async Task<ProductCommand> AddProductAsync(ProductCommand product)
        {
            _context.ProductDetails.Add(product);
            try
            {
                var result = await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return product;
        }
        public async Task<UserCommand> AddUserAsync(UserCommand user)
        {
            _context.userDetails.Add(user);
            try
            {
                var result = await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return user;
        }

        public async Task<bool> UpdateProductAsync(int productId,ProductCommand product)
        {
            _context.ProductDetails.Update(product);
            var response = (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
            return response;
        }

        public async Task<bool> UpdateInvoiceAsync(int invoiceId,InvoiceDetails invoice ,string role)
        {
            if (role == "adminJitu")
            {
                _context.InvoiceDetails.Update(invoice);
                var response = (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
                return response;
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var account = await _context.ProductDetails.FindAsync(productId).ConfigureAwait(false);

            if (account == null)
                return false;

            //Delete the account
            _context.ProductDetails.Remove(account);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteInvoiceAsync(int invoiceId,string role)
        {

            if (role == "adminJitu")
            {
                var account = await _context.InvoiceProductDetails.FindAsync(invoiceId).ConfigureAwait(false);

                if (account == null)
                    return false;

                //Delete the account
                _context.InvoiceProductDetails.Remove(account);

                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            return false;
        }

        public async Task<UserCommand> DeleteUserByIdAsync(string role, string phoneNumber)
        {
            var account = await _context.userDetails.FindAsync(phoneNumber).ConfigureAwait(false);
            if (role == "adminJitu")
            {
               

                //Delete the account
                _context.userDetails.Remove(account);

                await _context.SaveChangesAsync().ConfigureAwait(false);
                return new UserCommand(); 
            }
            return account;

        }

        public async Task<InvoiceDetails> AddCustomerDetailsAsync(InvoiceDetails invoiceDetails)
        {
             var invoiceAllData = new InvoiceDetails
        {
            fullName = invoiceDetails.fullName,
            fullAddress = invoiceDetails.fullAddress,
            paymentMode = invoiceDetails.paymentMode,
            phoneNumber = invoiceDetails.phoneNumber,
            totalAmount = invoiceDetails.totalAmount,
            status = invoiceDetails.status
           
        };

        // Add to context and save changes
        try{
        _context.InvoiceDetails.Add(invoiceAllData);
        await _context.SaveChangesAsync();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }
           // foreach (var productDetailsDto in invoiceDetails.InvoiceProductDetails)
                //for(int i=0;i< invoiceDetails.InvoiceProductDetails.size();i++)
           // {
               
           
        //return Ok("Invoice details added successfully");
            return invoiceDetails;
        }
    }
}
