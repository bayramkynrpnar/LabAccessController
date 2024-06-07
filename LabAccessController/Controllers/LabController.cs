using Data.Dto.Lesson;
using Dto.Lab;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Lab;
using Services.Lesson;

namespace LabAccessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabService labService;

        public LabController(ILabService labService)
        {
            this.labService = labService;
        }

        [HttpPost("lab")]
        public IActionResult AddLab(AddLabDto addLabDto)
        {
            var result = labService.AddLab(addLabDto);
            return Ok(result);
        }

        [HttpDelete("lab")]
        public IActionResult DeleteLab(int labId)
        {
            var result = labService.DeleteLab(labId);
            return Ok(result);
        }

        [HttpPut("lab")]
        public IActionResult UpdateLab(UpdateLabDto updateLab)
        {
            var result = labService.UpdateLab(updateLab);
            return Ok(result);
        }

        [HttpGet("lab")]
        public IActionResult GetLab(int labId)
        {
            var lab = labService.GetLab(labId);
            return Ok(lab);
        }

        [HttpGet("labs")]
        public IActionResult GetLabs()
        {
            var labs = labService.GetAllLabs();
            return Ok(labs);
        }
    }
}