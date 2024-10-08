﻿using Business.Abstracts;
using Business.Dtos.Requests.UserRequest;
using Core.DataAccess.Paging;
using Core.Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserBase user)
        {
            var result = await _userService.AddAsync(user);
            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _userService.GetAllAsync(pageRequest);
            return Ok(result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.UpdateAsync(updateUserRequest);
            return Ok(result);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _userService.GetById(userId);
            return Ok(result);
        }

    }
}

