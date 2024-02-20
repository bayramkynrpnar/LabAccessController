using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace DataAcces.Configuration.BaseConfig
{
    public class BaseConfig<TModel> : IEntityTypeConfiguration<TModel> where TModel : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
