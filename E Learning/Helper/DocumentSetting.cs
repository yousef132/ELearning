namespace E_Commerce.Helper
{
	public static class DocumentSetting
	{

		public static string UploadFile(IFormFile file , string folderName )
		{
			// 1. Locate Folder Path				
			var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Images", folderName);
			// 2. Set Unique Names for Files (  new id  + fileName)

			var filename = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

			// 3. get file path

			var filepath = Path.Combine(folderpath,filename);

			// 4. upload file on server

			using var filestream = new FileStream(filepath,FileMode.Create);

			file.CopyTo(filestream);

			return filename;
		}

		public static void DeleteFile(string folderName, string fileurl)
			=> File.Delete(GetImagePath(folderName, fileurl));		
		// user image or course image
		private static string GetImagePath(string folderName, string fileurl)
		{
			var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Images", folderName);

			return Path.Combine(folderpath,fileurl);
		}
	}
}
