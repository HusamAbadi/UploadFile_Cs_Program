using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UploadFileProg.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace UploadFileProg.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            FilesModel filenames = new FilesModel("wwwroot/images/");
            return View(filenames);
        }

        public IActionResult Delete(string delfile)
        {
            if (delfile != null)
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", delfile);
                System.IO.File.Delete(file);
                ViewData["success"] = true;

            }
            else
            {
                ViewData["success"] = false;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}