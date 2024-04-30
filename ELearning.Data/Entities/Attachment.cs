using ELearning.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace ELearning.Data.Entities
{
    public enum AttachmentType
    {
        Image,
        Video,
        Pdf,
    }
    public class Attachment:BaseEntity
    {
        public string Path { get; set; }
        public string Type { get; set; }

        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
    }
}
