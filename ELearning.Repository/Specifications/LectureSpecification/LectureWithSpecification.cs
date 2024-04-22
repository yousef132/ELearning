using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications.LectureSpecification
{
	public class LectureWithSpecification : BaseSpecification<Lecture>
	{
		public LectureWithSpecification(int lectureId)
			: base(lec=>lec.Id==lectureId)
		{
			AddInclude(lec=>lec.Attachments);	
		}
	}
}
