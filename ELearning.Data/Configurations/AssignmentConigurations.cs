using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Data.Configurations
{
    public class AssignmentConigurations : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.OwnsOne(x => x.TimedEntity, c =>
            {
                c.WithOwner();
            });
        }
    }
}
