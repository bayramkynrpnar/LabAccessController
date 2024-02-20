using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto.Lesson
{
    public class AddLessonDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
