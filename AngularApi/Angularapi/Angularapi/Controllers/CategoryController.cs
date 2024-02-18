using Angularapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angularapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/Values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var values =  _context.Categories.ToList();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data.");
            }
        }
        // GET api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var value = await _context.Categories.FindAsync(id);
                if (value == null)
                {
                    return NotFound();
                }

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data.");
            }
        }
        // POST api/Values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<CATEGORY> values)
        {
            if (values == null || values.Count == 0)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _context.Categories.AddRange(values);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving data.");
            }
        }
        // DELETE api/Values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var value = await _context.Categories.FindAsync(id);
                if (value == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(value);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting data.");
            }
        }

        // PUT api/Values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CATEGORY updatedValue)
        {
            if (updatedValue == null || id != updatedValue.Id)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _context.Entry(updatedValue).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "An error occurred while updating data.");
                }
            }
        }

        private bool ValueExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
