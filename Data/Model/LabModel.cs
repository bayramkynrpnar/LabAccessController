using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LabModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<LessonModel> LessonModels { get; set; }
    }
}
