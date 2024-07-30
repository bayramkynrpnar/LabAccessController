using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ExperimentModel : BaseEntity
    {
        public int LessonModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public virtual LessonModel LessonModel { get; set; }

    }
}
