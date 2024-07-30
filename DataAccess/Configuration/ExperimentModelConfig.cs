using Data.Model;
using DataAcces.Configuration.BaseConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ExperimentModelConfig : BaseConfig<ExperimentModel>
    {
        public override void Configure(EntityTypeBuilder<ExperimentModel> builder)
        {
            builder.HasOne(x => x.LessonModel).WithMany(x => x.ExperimentModels).HasForeignKey(x => x.LessonModelId);
            base.Configure(builder);
        }
    }
}