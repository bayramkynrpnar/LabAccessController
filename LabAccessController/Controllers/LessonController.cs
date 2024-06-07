using Data.Dto.Lesson;
using Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Lesson;

namespace LabAccessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService lessonService;

        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }

        [HttpPost("lesson")]
        public IActionResult AddUser(AddLessonDto addLessonDto)
        {
            var result = lessonService.AddLesson(addLessonDto);
            return Ok(result);
        }

        [HttpDelete("lesson")]
        public IActionResult DeleteLesson(int lessonId)
        {
            var result = lessonService.DeleteLesson(lessonId);
            return Ok(result);
        }

        [HttpPut("lesson")]
        public IActionResult UpdateLesson(UpdateLessonDto updateLesson)
        {
            var result = lessonService.UpdateLesson(updateLesson);
            return Ok(result);
        }

        [HttpGet("lesson")]
        public IActionResult GetLesson(int lessonId)
        {
            var lesson = lessonService.GetLesson(lessonId);
            return Ok(lesson);
        }

        [HttpGet("lessons")]
        public IActionResult GetLessons()
        {
            var lessons = lessonService.GetAllLessons();
            return Ok(lessons);
        }
    }
}