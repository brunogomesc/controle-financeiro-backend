using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.DAL.Interfaces;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {

            return await _categoryRepository.GetAll().ToListAsync();

        }

        // GET: api/Categories/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {

            var categorie = await _categoryRepository.GetById(id);

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

            if(ModelState.IsValid)
            {

                await _categoryRepository.Update(category);
                return Ok(new { 
                    message = $"Categoria {category.Name} atualizado com sucesso!"
                });

            }

            return BadRequest(ModelState);

        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {

            if(ModelState.IsValid)
            {

                await _categoryRepository.Insert(category);
                return Ok(new
                {
                    message = $"Categoria {category.Name} criada com sucesso!"
                });

            }

            return BadRequest(ModelState);

        }

        // DELETE: api/Categories/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {

            var category = await _categoryRepository.GetById(id);
            if(category == null)
            {

                return NotFound();

            }

            await _categoryRepository.Delete(id);

            return Ok(new
            {
                message = $"Categoria {category.Name} excluída com sucesso"
            });

        }

        // GET: api/FilterCategories/Shows
        [HttpGet("FilterCategories/{nameCategory}")]
        public async Task<ActionResult<IEnumerable<Category>>> FilterCategories(string nameCategory) {

            return await _categoryRepository.FilterCategories(nameCategory).ToListAsync();
        
        }

    }
}
