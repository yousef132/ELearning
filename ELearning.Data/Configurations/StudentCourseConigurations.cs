using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ELearning.Data.Configurations
{
    public class studentcourseconigurations : IEntityTypeConfiguration<StudentCourse>
    {

        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {

            builder.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
