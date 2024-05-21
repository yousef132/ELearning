using AutoMapper;
using E_Learning.Models;
using ELearning.DAL.Entities;

namespace E_Learning.MappingProfiles.Comment
{
	public class CommentProfile:Profile
	{
        public CommentProfile()
        {
            CreateMap<StudentLectureComment,CommentViewModel>().ReverseMap();
        }
    }
}
