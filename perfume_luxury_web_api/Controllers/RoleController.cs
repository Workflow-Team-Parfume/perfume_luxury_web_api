﻿using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace perfume_luxury_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string roleName)
        {
            await roleService.Create(roleName);
            return Ok();
        }
        [HttpPost("addToRole")]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            await roleService.AddToRole(userId, roleName);
            return Ok();
        }
        [HttpPost("removeFromRole")]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleName)
        {
            await roleService.RemoveFromRole(userId, roleName);
            return Ok();
        }
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> Delete([FromRoute] string roleName)
        {
            await roleService.Delete(roleName);
            return Ok();
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            return Ok(await roleService.GetByUserId(userId));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await roleService.GetAll());
        }
    }
}

