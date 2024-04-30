using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Learning.Models
{
    public class SpecificationsViewModel
    {
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> Levels { get; set; } = new List<string>();
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Name { get; set; }
        public int PageIndex { get; set; } = 1;
    }
}
