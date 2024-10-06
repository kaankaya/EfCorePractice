using Azure;
using ECommerce.Data;
using ECommerce.Dto;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePrice(int id, [FromBody] JsonPatchDocument<Product> patchDocument)
        {
            if(patchDocument is null)
            {
                return BadRequest("Patch döküman boş olamaz");
            }
            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound("ürün bulunamadı");
            }

            try
            {
                patchDocument.ApplyTo(product);
                if (product.Price <= 0)
                {
                    return BadRequest("Fiyat 0 veya sıfırdan küçük olamaz");
                }
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = entry.Entity as Product;
                var databaseEntry = entry.GetDatabaseValues();
                if(databaseEntry is null)
                {
                    return NotFound("Ürün Silinmiş");
                }

                var databaseValue = databaseEntry.ToObject() as Product;
                ModelState.AddModelError(string.Empty,"bu ürün fiyatı daha önbce başka kullanıcı tarafıdnan değiştirilmiş");
                return Conflict(new { 
                Message = "Conflict oluştu.Ürün Başka biri Tarafından Güncellendi",
                CurrentDatabaseValues = databaseValue,
                YourAttemptedValues = clientValues
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Hata Oluştu");
            }
        }
        
    }
}
