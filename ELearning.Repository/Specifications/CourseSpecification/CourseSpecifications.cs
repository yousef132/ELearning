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


		//public int PageSize { get; set; } = 6;
  //      public int PageIndex { get; set; } = 1;



        // for filtering 
        public List<string> Levels { get; set; } = new List<string>();

        public List<string> Languages { get; set; } = new List<string>();
		public List<string> Categories { get; set; } = new List<string>();
        public int MinPrice { get; set; }
		public int MaxPrice { get; set; }
		public string Sort {  get; set; }
    }
}
