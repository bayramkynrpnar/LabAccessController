using Data.Model;
using DataAcces.Context;
using DataAcces.Uow;
using Dto.Lab;
using Dto.User;
using Services.User;
using System.Reflection.Emit;

namespace Services.Lab
{
    public class LabService : ILabService
    {
        public int AddLab(AddLabDto addLab)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var labModel = new LabModel();
                labModel.Name = addLab.Name;
                labModel.Description = addLab.Description;

                uow.GetRepository<LabModel>().Add(labModel);

                return uow.SaveChanges();
            }
        }

        public int DeleteLab(int labId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lab = uow.GetRepository<LabModel>().Get(x => x.Id == labId);
                uow.GetRepository<LabModel>().Delete(lab);
                return uow.SaveChanges();
            }
        }


        public List<LabModel> GetAllLabs()
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var labList = uow.GetRepository<LabModel>().GetAll().ToList();
                return labList;
            }
        }


        public LabModel GetLab(int labId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var lab = uow.GetRepository<LabModel>().Get(x => x.Id == labId);
                return lab;
            }
        }

        public int UpdateLab(UpdateLabDto updateLab)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var labModel = uow.GetRepository<LabModel>().Get(x => x.Id == updateLab.LabId);
                labModel.Name = updateLab.Name;
                labModel.Description = updateLab.Description;

                return uow.SaveChanges();
            }
        }

        public IQueryable<LabModel> GetLabWithLesson(int lessonId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var labs = uow.GetRepository<LabModel>().GetAll();
                return labs;
            }
        }
    }
}