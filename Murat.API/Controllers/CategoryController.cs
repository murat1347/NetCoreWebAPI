using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Murat.API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoryController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public CategoryController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
            var data = _productContext.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);

            if (data == null)
            {
                return NotFound(id);
            }

            return Ok(data);

        }

    }
}
