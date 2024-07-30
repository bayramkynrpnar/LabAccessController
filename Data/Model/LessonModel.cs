using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LessonModel : BaseEntity
    {
        public int LabModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ExperimentModel> ExperimentModels{ get; set; }
        public virtual LabModel LabModel { get; set; }
    }
}
