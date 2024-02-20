

using Data.Dto.Lesson;
using Data.Model;
using DataAcces.Context;
using DataAcces.Uow;
using Dto.Lab;
using Dto.User;
using Services.User;

namespace Services.Lesson
{
    public class LessonService : ILessonService
    {
        public int AddLesson(AddLessonDto addLesson)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lessonModel = new LessonModel();
                lessonModel.Name = addLesson.Name;
                lessonModel.Description = addLesson.Description;
                lessonModel.UserId = addLesson.UserId;

                uow.GetRepository<LessonModel>().Add(lessonModel);

                return uow.SaveChanges();
            }
        }

        

      

        public int DeleteLesson(int lessonId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lesson = uow.GetRepository<LessonModel>().Get(x => x.Id == lessonId);
                uow.GetRepository<LessonModel>().Delete(lesson);
                return uow.SaveChanges();
            }
        }

        public List<LessonModel> GetAllLessons()
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lessonList = uow.GetRepository<LessonModel>().GetAll().ToList();
                return lessonList;
            }
        }

        public LessonModel GetLesson(int lessonId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lesson = uow.GetRepository<LessonModel>().Get(x => x.Id == lessonId);
                return lesson;
            }
        }

        public int UpdateLesson(UpdateLessonDto updateLesson)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lessonModel = uow.GetRepository<LessonModel>().Get(x => x.Id == updateLesson.UserId);
                lessonModel.Name = updateLesson.Name;
                lessonModel.Description = updateLesson.Description;
                lessonModel.UserId = updateLesson.UserId;

                return uow.SaveChanges();
            }
        }

        public IQueryable<LessonModel> GetLessonsWithTeacher(int userId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lessons = uow.GetRepository<LessonModel>().GetAll(x => x.UserId == userId);
                return lessons;
            }
        }


    }
}
