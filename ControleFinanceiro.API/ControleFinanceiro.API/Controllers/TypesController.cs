using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {

        private readonly ITypeRepository _typeRepository;

        public TypesController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.Models.Type>>> GetTypes()
        {

            return await _typeRepository.GetAll().ToListAsync();

        }
    }
}
