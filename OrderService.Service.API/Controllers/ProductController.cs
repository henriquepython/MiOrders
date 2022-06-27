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
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(await productService.GetAllProducts());
        }

        // GET BY ID
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            var productId = await productService.GetProductById(id);
            if (productId is null)
            {
                return NotFound("product not found");
            }

            return Ok(productId);
        }

        // GET BY CATEGORY
        [HttpGet("/category/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(ProductCategory category)
        {
            var categoryProduct = await productService.GetProductByCategory(category);
            
            if (categoryProduct is null)
            {
                return NotFound("category not found");
            }

            return Ok(categoryProduct);
        }

        // GET BY TITLE
        [HttpGet("/title/{title}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByTitle(string title)
        {
            var titleProduct = await productService.GetProductByTitle(title);

            if (titleProduct is null)
            {
                return NotFound("title not found");
            }

            return Ok(titleProduct);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<CreateProductViewModel>> Post([FromBody] CreateProductViewModel product)
        {
            var selectProduct = mapper.Map<Product>(product);
            var createdProduct = await productService.CreateProduct(selectProduct);
            return new CreatedAtRouteResult("GetProduct", new { id = selectProduct.id}, createdProduct);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateProductViewModel>> Put(Guid id, [FromBody] Product product)
        {
            var result = await productService.GetProductById(id);
            
            if (result is null)
            {
                return BadRequest();
            }
            
            await productService.UpdateProduct(product);
            
            return new CreatedAtRouteResult("GetProduct", new {id = product.id}, product) ;
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<Product> Delete(Guid id)
        {
           return await productService.DeleteProduct(id);
        }
    }
}
