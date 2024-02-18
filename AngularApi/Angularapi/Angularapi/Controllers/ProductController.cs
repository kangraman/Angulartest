using Angularapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angularapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data.");
            }
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data.");
            }
        }

        // POST api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PRODUCT product)
        {
            
            if (product == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var Category = _context.Categories.Where(x => x.Name == product.CategoryName).FirstOrDefault();
                PRODUCT obj = new PRODUCT();
                obj.CategoryId = Category.Id;
                obj.Name = product.Name;
                obj.CategoryName = product.CategoryName;
                obj.Description = product.Description;
                obj.IMAGE = product.IMAGE;
                _context.Products.Add(obj);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving data.");
            }
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PRODUCT updatedProduct)
        {
            if (updatedProduct == null || id != updatedProduct.Id)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _context.Entry(updatedProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "An error occurred while updating data.");
                }
            }
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting data.");
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
