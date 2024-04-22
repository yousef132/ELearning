using ELearning.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Context
{
    public class ApplicationUser : IdentityUser
    {
        //  teacher has many courses
        public ICollection<Course> TeacherCourses { get; set; }
        // student has many courses
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
        // student courses
        public ICollection<StudentExam> StudentExams { get; set; }
        public ICollection<StudentQuestion> StudentQuestions { get; set; }

        public string ImagePath { get; set; }
        public string DisplayName { get; set; }




    }
}
