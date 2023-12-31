﻿using Core.Dtos.Amount;
using Core.Dtos.Category;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryService.Get());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await categoryService.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO category)
        {
            if (!ModelState.IsValid) return BadRequest();
            await categoryService.Create(category);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await categoryService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoryDTO category)
        {
            if (!ModelState.IsValid) return BadRequest();

            await categoryService.Edit(category);

            return Ok();
        }
    }
}
