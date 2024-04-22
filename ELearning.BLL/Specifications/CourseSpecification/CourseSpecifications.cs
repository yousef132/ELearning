using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications.CourseSpecification
{
	public class CourseSpecifications
	{
		public string? Name { get; set; }
		public string? UserId { get; set; } 
		public int? CourseId { get; set; }	
    }
}
