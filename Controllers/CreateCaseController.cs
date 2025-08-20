using casman_WEBAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using casman_WEBAPI.Models;

namespace casman_WEBAPI.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class CreateCaseController : ControllerBase
        {
            private readonly ICaseRepository _caseRepository;

            public CreateCaseController(ICaseRepository caseRepository)
            {
                _caseRepository = caseRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewCase([FromBody] CreateCaseDto dto)
        {
            try
            {
                await _caseRepository.CreateNewCaseAsync(dto);
                return Ok(new { message = "Case created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("indemnifiers")]
        public async Task<ActionResult<List<IndemnifierDto>>> GetIndemnifiers()
        {
            var indemnifiers = await _caseRepository.GetIndemnifiersAsync();
            return Ok(indemnifiers);
        }
    }
}

