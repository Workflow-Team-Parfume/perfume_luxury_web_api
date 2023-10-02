using Core.Dtos.Brand;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await brandService.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await brandService.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandDTO brand)
        {
            if (!ModelState.IsValid) return BadRequest();
            await brandService.Create(brand);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await brandService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] BrandDTO brand)
        {
            if (!ModelState.IsValid) return BadRequest();

            await brandService.Edit(brand);

            return Ok();
        }
    }
}
