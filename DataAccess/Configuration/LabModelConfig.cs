﻿using Data.Model;
using DataAcces.Configuration.BaseConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class LabModelConfig : BaseConfig<LabModel>
    {
        public override void Configure(EntityTypeBuilder<LabModel> builder)
        {
            builder.HasMany(x => x.LessonModels).WithOne(x => x.LabModel).HasForeignKey(x => x.LabModelId);

            base.Configure(builder);
        }
    }
}