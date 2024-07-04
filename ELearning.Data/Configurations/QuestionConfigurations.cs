using ELearning.Data.Entities.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.DAL.Configurations
{
    public class QuestionConfigurations : IEntityTypeConfiguration<BaseQuestion>
    {
        public void Configure(EntityTypeBuilder<BaseQuestion> builder)
        {
            builder.HasMany(q => q.StudentAnswers)
                .WithOne(sa => sa.BaseQuestion)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
