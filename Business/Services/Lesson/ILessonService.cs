using Data.Dto.Lesson;
using Data.Model;
using Dto.Lab;
using Dto.User;

namespace Services.Lesson
{
    public interface ILessonService
    {
        public int AddLesson(AddLessonDto addLesson);
        public int UpdateLesson(UpdateLessonDto updateLesson);
        public int DeleteLesson(int lessonId);
        public LessonModel GetLesson(int lessonId);
        public List<LessonModel> GetAllLessons();
        public IQueryable<LessonModel> GetLessonsWithTeacher(int userId);
    }
}
