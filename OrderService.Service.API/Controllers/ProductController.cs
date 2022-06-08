using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GETAll
        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> Get()
        {
            return Ok(await productService.GetAllProducts());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            return Ok(await productService.GetProductById(id));
        }

        // GET BY CATEGORY
        [HttpGet("/category/{category}")]
        public async Task<ActionResult<Product>> GetByCategory(string category)
        {
            return Ok(await productService.GetProductByCategory(category));
        }

        // GET BY TITLE
        [HttpGet("/title/{title}")]
        public async Task<ActionResult<Product>> GetByTitle(string title)
        {
            return Ok(await productService.GetProductByTitle(title));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            return Ok(await productService.CreateProduct(product));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
        {
            var result = await productService.GetProductById(id);
            if (result != null)
            {
                return Ok(await productService.UpdateProduct(product));
            }
            return BadRequest();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await productService.DeleteProduct(id);
        }
    }
}
