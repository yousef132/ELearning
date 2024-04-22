using ELearning.Data.Entities.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Configurations
{
    public class QuestionConigurations : IEntityTypeConfiguration<BaseQuestion>
    {
        public void Configure(EntityTypeBuilder<BaseQuestion> builder)
        {
            // basequstion owns many choices and choice owns one answer
            builder.OwnsMany(x => x.Choices, c =>
            {
                c.WithOwner();
            });

        }
    }

}
