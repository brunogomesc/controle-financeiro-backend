using ControleFinanceiro.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {

        private readonly Context _context;

        public TypesController(Context context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.Models.Type>>> GetTypes()
        {

            return await _context.Types.ToListAsync();

        }
    }
}
