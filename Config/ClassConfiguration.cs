using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_EF.models;

namespace TP1_EF.Config
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasOne(c => c.Teacher)
                   .WithMany(t => t.Classes)
                   .HasForeignKey(c => c.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
