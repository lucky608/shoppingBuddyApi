using KisaanCafe.Models;
using KisaanCafe.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace KisaanCafeWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet("GetAllProducts", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProductAsync(string phoneNumber,string password)
        {
            var user = await _services.GetUserByPhPassAsync(phoneNumber, password);

            try
            {
                if (user != null) { 
                var products = await _services.GetProductDetailsAsync();

                if (products == null || !products.Any())
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(products);
            }else
            {
                return null;
            }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync(string role)
        {
            try
            {
                var products = await _services.GetAllUsersAsync(role);

                if (products == null || !products.Any())
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("DeleteUserById", Name = "DeleteUserById")]
        public async Task<IActionResult> DeleteUserByIdAsync(string role,string phoneNumber)
        {
            try
            {
                var products = await _services.DeleteUserByIdAsync(role,phoneNumber);

                if (products == null)
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetUserByPhPass", Name = "GetUserByPhPass")]
        public async Task<IActionResult> GetUserByPhPassAsync(string phone, string password)
        {
            try
            {
                var user = await _services.GetUserByPhPassAsync( phone,  password);

                if (user == null)
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPost("AddProduct", Name = "AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductCommand product, string role)
        {
            try
            {
                if (role == "adminJitu")
                {
                    var addedProducts = await _services.AddProductAsync(product).ConfigureAwait(false);
                    return Ok(addedProducts);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }

        [HttpPost("AddUser", Name = "AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserCommand user,string role)
        {
            try
            {
                if (role == "adminJitu")
                {
                    var addedProducts = await _services.AddUserAsync(user).ConfigureAwait(false);
                    return Ok(addedProducts);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }

        [HttpPost("AddInvoice", Name = "AddInvoice")]
        public async Task<IActionResult> AddCustomerDetailsAsync([FromBody] InvoiceDetails invoiceDetails)
        {
            try
            {
                var addedInvoiceData = await _services.AddCustomerDetailsAsync(invoiceDetails).ConfigureAwait(false);
                return Ok(addedInvoiceData);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetInvoice", Name = "GetInvoice")]
        public async Task<IActionResult> GetInvoiceAsync(string mobileNumber)
        {
            try
            {
                var invoiceDetails = await _services.GetInvoiceAsync(mobileNumber);

                if (invoiceDetails == null || !invoiceDetails.Any())
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(invoiceDetails);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("DeleteInvoice", Name = "DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoiceAsync(int invoiceId,string role)
        {

            try
            {
                var isProductDelete = await _services.DeleteInvoiceAsync(invoiceId,role).ConfigureAwait(false);
                return Ok(isProductDelete);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetAllInvoice", Name = "GetAllInvoice")]
        public async Task<IActionResult> GetAllInvoiceAsync(string role)
        {
            try
            {
                var invoiceDetails = await _services.GetAllInvoiceAsync(role);

                if (invoiceDetails == null || !invoiceDetails.Any())
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(invoiceDetails);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("{productId}", Name = "UpdateProduct")]
        public async Task<PutActionResult> UpdateProductAsync(int productId, [FromBody] ProductCommand product,string role)
        {
            if (role == "adminJitu")
            {
                product.Id = productId;
                return await _services.UpdateProductAsync(productId, product).ConfigureAwait(false);
            }else {
                return null;
            }
        }

        [HttpPut]
        [Route("{invoiceId}", Name = "UpdateInvoice")]
        public async Task<PutActionResult> UpdateInvoiceAsync(int invoiceId, [FromBody] InvoiceDetails invoice,string role)
        {
            invoice.Id = invoiceId;
            return await _services.UpdateInvoiceAsync(invoiceId, invoice, role).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{productId}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync(int productId,string role)
        {
             
            try
            {
                if (role == "adminJitu")
                {
                    var isProductDelete = await _services.DeleteProductAsync(productId).ConfigureAwait(false);
                    return Ok(isProductDelete);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }
    }
}
