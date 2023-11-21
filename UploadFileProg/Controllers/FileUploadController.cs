using Microsoft.AspNetCore.Mvc;

namespace UploadFileProg.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0  ) {
                    return Content("No selected file!");
                }
                ViewData["filename"] = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                ViewData["success"] = true;
            }
            catch
            {
                ViewData["success"] = false;
            }
            return View();
        }
    }
}
