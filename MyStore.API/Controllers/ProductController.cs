using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Dtos;
using MyStore.Application.Products;
using AutoMapper;


namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;      

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto product)
        {            
            await _service.CreateAsync(product);
            return Ok(product);
        }
    }
}
