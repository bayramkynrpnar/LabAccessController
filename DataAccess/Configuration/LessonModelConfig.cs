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
    internal class LessonModelConfig : BaseConfig<LessonModel>
    {
        public override void Configure(EntityTypeBuilder<LessonModel> builder)
        {
            builder.HasMany(x => x.ExperimentModels).WithOne(x => x.LessonModel).HasForeignKey(x => x.LessonModelId);

            base.Configure(builder);
        }
    }
}