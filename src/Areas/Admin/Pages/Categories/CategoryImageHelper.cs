namespace QuizProject.Areas.Admin.Pages.Categories
{
    public static class CategoryImageHelper
    {
        public static async Task CreateImage(string id, IFormFile Upload, IWebHostEnvironment _environment)
        {            
            var newFileName = id + Path.GetExtension(Upload.FileName);
            var file = Path.Combine(_environment.ContentRootPath, @"wwwroot\img", newFileName);

            if (File.Exists(file)) File.Delete(file);

            using (var fileStream = new FileStream(file, FileMode.CreateNew))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
        public static bool ExistImage(string id, IWebHostEnvironment _environment)
        {
            var newFileName = id + ".png";
            var file = Path.Combine(_environment.ContentRootPath, @"wwwroot\img", newFileName);
            return File.Exists(file);            
        }
    }
}