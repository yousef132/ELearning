using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Data.Configurations
{
    public class StudentQuestionConigurations : IEntityTypeConfiguration<StudentQuestion>
    {
        public void Configure(EntityTypeBuilder<StudentQuestion> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.BaseQuestionId,
            });
        }
    }
}
