using ELearning.Data.Context;
using ELearning.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ELearningDbContext context;

        public AttachmentRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Attachment> GetAttachmentsByLectureId(int lectureId)
            => context.Attachments.Where(a => a.LectureId == lectureId).ToList();
        
    }
    public class ExamRepository : IExamRepository
    {
        private readonly ELearningDbContext context;

        public ExamRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Exam> GetExamsByCourseId(int courseId)
            => context.Exams.Where(a => a.CourseId == courseId).ToList();
        
    }
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ELearningDbContext context;

        public AssignmentRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Assignment> GetAssignmentsByCourseId(int courseId)
            => context.Assignments.Where(a => a.CourseId == courseId).ToList();
        
    }
}
