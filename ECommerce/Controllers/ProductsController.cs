using ECommerce.Data;
using ECommerce.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ECommerceContext _context;
        //context atamasını yaptık
        public ProductsController(ECommerceContext context)
        {
            _context = context;
        }

        [HttpPut("{productName}")]
        public async Task<IActionResult> UpdateProduct(string productName,ProductUpdateDto updateDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p=>p.Name == productName);
            if (product is null) 
            {
                return NotFound($"{productName} adlı ürün bulunamdı");
            }

            try
            {
                product.Price *= (1 + (updateDto.PriceIncreasePercenteage / 100));
                product.StockQuantity += updateDto.StockIncrease;
                await _context.SaveChangesAsync();
                //anonim obje gönderdik
                return Ok(new 
                {
                    Message = "Ürün Güncellendi",
                    productName = productName,
                    NewPrice = product.Price,
                    NewStockQuantity = product.StockQuantity
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ürün Güncellerken Hata Oluştu");
                
            }
        }
        
    }
}
