using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : Controller
    {
        private readonly IPerfumeService perfumeService;

        public PerfumesController(IPerfumeService perfumeService)
        {
            this.perfumeService = perfumeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await perfumeService.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await perfumeService.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePerfumeDTO perfume)
        {
            if (!ModelState.IsValid) return BadRequest();

            await perfumeService.Create(perfume);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await perfumeService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditPerfumeDTO perfume)
        {
            if (!ModelState.IsValid) return BadRequest();

            await perfumeService.Edit(perfume);

            return Ok();
        }
    }
}
