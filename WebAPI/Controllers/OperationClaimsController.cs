﻿using Business.Abstracts;
using Business.Dtos.Requests.OperationClaimRequests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _operationClaimService.GetListAsync(pageRequest);
            return Ok(result);
        }

        
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOperationClaimRequest createOperationClaimRequest)
        {
            var result = await _operationClaimService.AddAsync(createOperationClaimRequest);
            return Ok(result);
        }


        
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] int id)
        {
            var result = await _operationClaimService.DeleteAsync(id);
            return Ok(result);
        }


        
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            var result = await _operationClaimService.UpdateAsync(updateOperationClaimRequest);
            return Ok(result);
        }

    }
}

