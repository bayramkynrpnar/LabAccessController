using Data.Dto.Experiment;
using Data.Model;
using Dto.User;

namespace Services.Experiment
{
    public interface IExperimentService
    {
        public int AddExperiment(AddExperimentDto addExperiment);
        public int UpdateExperiment(UpdateExperimentDto updateUser);
        public int DeleteExperiment(int experimentId);
        public ExperimentModel GetExperiment(int experimentId);
        public List<ExperimentModel> GetAllExperiments();
        public List<ExperimentModel> GetExperimentWithLab(int labId);
        public string TakeExperimentQrCode(int userId, int experimentId);
    }
}
