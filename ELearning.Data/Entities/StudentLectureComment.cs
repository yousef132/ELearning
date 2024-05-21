using ELearning.DAL.Context.Identity;
using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Entities
{
	public class StudentLectureComment:BaseEntity
	{
		[ForeignKey("Student")]
		public string StudentId { get; set; }
		public ApplicationUser Student { get; set; }
		public string Comment { get; set; }

		public Lecture Lecture { get; set; }
		public int LectureId { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;	
	}

}
