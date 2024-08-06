using Business.Abstracts;
using Business.Dtos.Requests.DutyRequest;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutiesController : ControllerBase
    {
        IDutyService _dutyService;

        public DutiesController(IDutyService dutyService )
        {
            _dutyService = dutyService;
        }


        [HttpPost ("Add")]
        public async Task<IActionResult> Add([FromBody] CreateDutyRequest createDutyRequest)
        {
            var result= await _dutyService.AddAsync (createDutyRequest);
            return Ok(result); 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest )
        {
            var result = await _dutyService.GetAllAsync (pageRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDutyRequest updateDutyRequest)
        {
            var result = await _dutyService.UpdateAsync (updateDutyRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var result = await (_dutyService.DeleteAsync (id));
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _dutyService.GetById(id);
            return Ok(result);
        }

    }
}
