﻿namespace E_Learning.Models
{
    public class AttachmentViewModel
    {
        public string Name { get; set; }
        public int? LectureId { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
