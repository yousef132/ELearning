using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Data.Configurations
{
    public class StudentAssignmentConigurations : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.HasKey(x => new
            {
                x.Id,
            });
        }
    }
}
