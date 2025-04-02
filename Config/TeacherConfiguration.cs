using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using TP1_EF.models;

namespace TP1_EF.Config
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasOne(t => t.Subject)
                   .WithMany(s => s.Teachers)
                   .HasForeignKey(t => t.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
