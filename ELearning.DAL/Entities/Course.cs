using ELearning.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities
{
    public class Course:BaseEntity
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public TimeSpan Duration { get; set; }

        public double Price { get; set; }

        public string Language {  get; set; }   


        public string Description { get; set; }

        public int NumberOfLectures { get; set; }

        public string ImagePath { get; set; }

        public string SkillLevel { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        
        public ICollection<Lecture> Lectures { get; set; }

    }
}
