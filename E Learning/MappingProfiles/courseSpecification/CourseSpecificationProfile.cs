using AutoMapper;
using E_Learning.Models;
using ELearning.BLL.Specifications.CourseSpecification;

namespace E_Learning.MappingProfiles.courseSpecification
{
    public class CourseSpecificationProfile: Profile
    {
        public CourseSpecificationProfile()
        {
            CreateMap<CourseSpecifications, SpecificationsViewModel>().ReverseMap();
        }
    }
}
