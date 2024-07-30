using Data.Dto.Experiment;
using Data.Model;
using DataAcces.Context;
using DataAcces.Uow;
using Dto.User;
using Elasticsearch.Net;
using QRCoder;
using System.Drawing;
using System.Net.Mime;
using System.Reflection.Emit;
using Utilies.Bitmap;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Services.Experiment
{
    public class ExperimentService : IExperimentService
    {
        public int AddExperiment(AddExperimentDto addExperiment)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experimentModel = new ExperimentModel();
                experimentModel.Name = addExperiment.Name;
                experimentModel.StartDate = addExperiment.StartDate;
                experimentModel.Description = addExperiment.Description;
                experimentModel.LessonModelId = addExperiment.LessonModelId;

                uow.GetRepository<ExperimentModel>().Add(experimentModel);

                return uow.SaveChanges();
            }
        }


        public int DeleteExperiment(int experimentId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experiment = uow.GetRepository<ExperimentModel>().Get(x => x.Id == experimentId);
                uow.GetRepository<ExperimentModel>().Delete(experiment);
                return uow.SaveChanges();
            }
        }


        public List<ExperimentModel> GetAllExperiments()
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experimentList = uow.GetRepository<ExperimentModel>().GetAll().ToList();
                return experimentList;
            }
        }


        public ExperimentModel GetExperiment(int experimentId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experiment = uow.GetRepository<ExperimentModel>().Get(x => x.Id == experimentId);
                return experiment;
            }
        }

        public int UpdateExperiment(UpdateExperimentDto updateExperiment)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experiment = uow.GetRepository<ExperimentModel>().Get(x => x.Id == updateExperiment.ExperimentId);
                experiment.Name = updateExperiment.Name;
                experiment.StartDate = updateExperiment.StartDate;
                experiment.Description = updateExperiment.Description;


                return uow.SaveChanges();
            }
        }


        public List<ExperimentModel> GetExperimentWithLab(int labId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var experiments = uow.GetRepository<ExperimentModel>().GetAll(x => x.LessonModelId == labId).ToList();
                return experiments;
            }
        }

        public int AddStudentToExperiment(int userId, int experimentId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var studentToExperiment = new StudentToExperiment()
                {
                    ExperimentId = experimentId,
                    UserId = userId,
                    QrCodeText = userId.ToString() + experimentId.ToString(),
                };

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData =
                    qrGenerator.CreateQrCode(studentToExperiment.QrCodeText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(60);


                uow.GetRepository<StudentToExperiment>().Add(studentToExperiment);
                return uow.SaveChanges();
            }
        }

        public string TakeExperimentQrCode(int userId, int experimentId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var student = uow.GetRepository<StudentToExperiment>()
                    .Get(x => x.UserId == userId && x.ExperimentId == experimentId);

                return student.QrCodeText;
            }
        }

        //public string LoginExperiment(BitmapExtension)
        //{
        //    using (var uow = new UnitOfWork<PostgresContext>())
        //    {
        //        var student = uow.GetRepository<StudentToExperiment>().Get(x => x.UserId == userId && x.ExperimentId == experimentId);

        //        return student.QrCodeText;
        //    }
        //}
    }
}