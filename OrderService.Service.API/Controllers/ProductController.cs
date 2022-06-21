using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
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
        public async Task<ActionResult<Product>> GetByCategory(ProductCategory category)
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
        public async Task<ActionResult<CreateProductViewModel>> Post([FromBody] CreateProductViewModel product)
        {
            return Ok(await productService.CreateProduct(mapper.Map<Product>(product)));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
        {
            var result = await productService.GetProductById(id);
            
            if (result == null)
            {
                return BadRequest();
            }
            
            return Ok(await productService.UpdateProduct(product));
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await productService.DeleteProduct(id);
        }
    }
}
