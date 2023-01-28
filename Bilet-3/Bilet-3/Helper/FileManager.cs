namespace Bilet_3.Helper
{
    public static class FileManager
    {
        public static bool IsImage(IFormFile file)
        {
            if (file.ContentType == "image/png" || file.ContentType=="image/jpeg")
            {
                return true;
            }
            return false;
        }

        public static bool CheckImageFile(IFormFile file)
        {
            if (file.Length < 3145728)
            {
                return true;
            }
            return false;
        }


        public static string CheckAndReturnName(IFormFile file)
        {
            string name = file.FileName;

            if (name.Length>64)
            {
                name = name.Substring(name.Length- 64);
            }
            name = Guid.NewGuid().ToString() + name;
            return name;

        }

        public static void SaveFile(IFormFile file,string path)
        {
            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }
        } 

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

    }
}
