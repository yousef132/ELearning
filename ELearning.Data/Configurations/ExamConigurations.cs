using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Data.Configurations
{
    public class ExamConigurations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.OwnsOne(x => x.TimedEntity, c =>
            {
                c.WithOwner();
            });
        }
    }
}
