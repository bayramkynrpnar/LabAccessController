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
    public class UserModelConfig : BaseConfig<UserModel>
    {
        public override void Configure(EntityTypeBuilder<UserModel> builder)
        {


            builder.HasData(
                new UserModel()
                {
                    Id = 1,
                    Name = "Name",
                    Surname = "S",
                    Email = "S",
                    Number ="055",
                    Password = "S",

                }

                );

            base.Configure(builder);
        }
    }
}
