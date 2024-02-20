using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class StudentToExperiment : BaseEntity
    {
        public int ExperimentId { get; set; }
        public int UserId { get; set; }
        public virtual ExperimentModel? ExperimentModel { get; set; }
        public string QrCodeText { get; set; } = "";
    }
}
