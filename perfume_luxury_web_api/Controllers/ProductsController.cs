using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Dtos.ParfumePiece;
using Core.Dtos.Perfume;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productService.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await productService.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await productService.Create(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await productService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await productService.Edit(product);

            return Ok();
        }
    }
}
