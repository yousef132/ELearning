namespace E_Commerce.Helper
{
    public static class DocumentSetting
    {

        public static string UploadFile(IFormFile file, string folderType, string folderName = "")
        {
            // 1. Locate Folder Path												 videos or images |   like (lectures, courses,user)
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/{folderType}", folderName);
            // 2. Set Unique Names for Files (  new id  + fileName)

            var filename = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            // 3. get file path

            var filepath = Path.Combine(folderpath, filename);

            // 4. upload file on server

            using var filestream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(filestream);

            return filename;
        }

        public static void DeleteFile(string folderType, string folderName, string fileurl)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/{folderType}", folderName);

            var path = Path.Combine(folderpath, fileurl);

            File.Delete(path);
        }
        public static string GetPath(string fileName)
            => Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/Videos/Lectures/{fileName}");

        public static string GetAssignmentPath(string fileName)
            => Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/Assignments/{fileName}");


    }
}
