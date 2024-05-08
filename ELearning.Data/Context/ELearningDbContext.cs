using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ELearning.Data.Entities;
using ELearning.Data.Entities.Question;

namespace ELearning.Data.Context
{
    public class ELearningDbContext:IdentityDbContext
    {
        public ELearningDbContext(DbContextOptions<ELearningDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
        public DbSet<Course> Courses { get; set; }   
        public DbSet<BaseQuestion> BaseQuestions { get; set; }   
        public DbSet<Assignment> Assignments { get; set; }   
        public DbSet<Attachment> Attachments { get; set; }   
        public DbSet<Exam> Exams { get; set; }   
        public DbSet<StudentCourse> StudentCourses { get; set; }   
        public DbSet<StudentAssignment> StudentAssignments { get; set; }   
        public DbSet<StudentExam> StudentExams { get; set; }   
        public DbSet<StudentAnswer> StudentQuestions { get; set; }   
        public DbSet<Lecture> Lectures { get; set; }   
    }
}
