﻿using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.DAL.Configurations
{
    public class StudentAnswerConfigurations : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.HasOne(sa => sa.BaseQuestion)
                   .WithMany(bq => bq.StudentAnswers)
                   .HasForeignKey(sa => sa.BaseQuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
