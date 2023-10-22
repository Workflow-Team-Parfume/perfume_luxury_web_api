using Core.Dtos.Parfume;
using Core.Dtos.ParfumePiece;
using Core.Dtos.Perfume;
using Core.Dtos.Product;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParfumeController : Controller
    {
        private readonly IParfumeService parfumeService;

        public ParfumeController(IParfumeService parfumeService)
        {
            this.parfumeService = parfumeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductParfumeDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await parfumeService.Create(product);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await parfumeService.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await parfumeService.GetById(id);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditProductParfumeDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await parfumeService.Edit(product);

            return Ok();
        }
    }
}
