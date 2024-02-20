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


            builder.HasData(
                new LessonModel()
                {
                    Description = "Description",
                    Id = 1,
                    Name = "Name",
                    UserId = 1,
                  

                }

                );

            base.Configure(builder);
        }
    }
}
