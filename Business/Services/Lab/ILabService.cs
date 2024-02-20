using Data.Model;
using Dto.Lab;
using Dto.User;

namespace Services.Lab
{
    public interface ILabService
    {
        public int AddLab(AddLabDto addLab);
        public int UpdateLab(UpdateLabDto updateLab);
        public int DeleteLab(int labId);
        public LabModel GetLab(int labId);
        public List<LabModel> GetAllLabs();
        public IQueryable<LabModel> GetLabWithLesson(int lessonId);
    }
}
