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
    public class StudentToExperimentConfig : BaseConfig<StudentToExperiment>
    {
        public override void Configure(EntityTypeBuilder<StudentToExperiment> builder)
        {
            builder.HasData(
                new StudentToExperiment()
                {
                    Id = 1,
                    ExperimentId = 1,
                    UserId = 1,
                }
            );

            base.Configure(builder);
        }
    }
}