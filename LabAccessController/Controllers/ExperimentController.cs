using Data.Dto.Experiment;
using Dto.Lab;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using Services.Experiment;
using Services.Lab;
using System.Drawing;
using System.Net.Mime;
using Utilies.Bitmap;
using ZXing;

namespace LabAccessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        private readonly IExperimentService experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            this.experimentService = experimentService;
        }

        [HttpPost("Experiment")]
        public IActionResult AddExperiment(AddExperimentDto addExperimentDto)
        {
            var result = experimentService.AddExperiment(addExperimentDto);
            return Ok(result);
        }

        [HttpDelete("Experiment")]
        public IActionResult DeleteLab(int expId)
        {
            var result = experimentService.DeleteExperiment(expId);
            return Ok(result);
        }

        [HttpPut("Experiment")]
        public IActionResult UpdateLab(UpdateExperimentDto updateexp)
        {
            var result = experimentService.UpdateExperiment(updateexp);
            return Ok(result);
        }

        [HttpGet("Experiment")]
        public IActionResult GetLab(int expId)
        {
            var experiment = experimentService.GetExperiment(expId);
            return Ok(experiment);
        }

        [HttpGet("Experiments")]
        public IActionResult GetLabs()
        {
            var experiments = experimentService.GetAllExperiments();
            return Ok(experiments);
        }

        [HttpGet("TakeQrCodeExperiment")]
        public IActionResult TakeQrCodeExperiment(int userId, int experimentId)
        {
            var Qr = experimentService.TakeExperimentQrCode(userId, experimentId);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Qr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(60);
            byte[] bitmapArray = qrCodeImage.BitmapToByteArray();

            return File(bitmapArray, MediaTypeNames.Image.Jpeg, userId + ".jpeg");
        }

        [HttpGet("LoginExperiment")]
        public IActionResult TakeQrCodeExperiments(IFormFile image)
        {
            return Ok();
        }
    }
}