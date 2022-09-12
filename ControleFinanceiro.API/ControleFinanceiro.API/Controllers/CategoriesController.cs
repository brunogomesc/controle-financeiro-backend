using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly Context _context;

        public CategoriesController(Context context)
        {

            _context = context;

        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {

            return await _context.Categories.Include(c => c.Type).ToListAsync();

        }

        // GET: api/Categories/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {

            var categorie = await _context.Categories.FindAsync(id);

            if(categorie == null)
            {

                return NotFound();

            }

            return categorie;

        }

        // PUT: api/Categories/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, Category category)
        {

            if(id != category.CategoryId)
            {

                return BadRequest();

            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {

                if(!CategoryExists(id))
                {

                    return NotFound();

                }
                else
                {

                    throw;

                }
            }

            return NoContent();

        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);

        }

        // DELETE: api/Categories/2
        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {

            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {

                return NotFound();

            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;

        }

        private bool CategoryExists(int id)
        {

            return _context.Categories.Any(e => e.CategoryId == id);

        }
    }
}
