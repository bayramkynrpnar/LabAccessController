using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LabModel : BaseEntity
    {
        public int LessonModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LessonModel? LessonModel { get; set; }

    }
}
