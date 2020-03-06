using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesSearch.Controllers
{
    public class ImageController : Controller
    {
        //private readonly DataContext _cc;

        IWebHostEnvironment _env;
        public ImageController(IWebHostEnvironment environment)
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadpath = _env.WebRootPath + imagePath;

                //create directory
                if (!Directory.Exists(uploadpath))
                {
                    Directory.CreateDirectory(uploadpath);
                   // this._cc.imdb(model.FileAttach.FileName, fileContentType, fileContent);
                }
            

                //create uniq file
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string filePath = uploadpath + filename;


                imagePath = imagePath + @"\";
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                ViewData["FileLocation"] = filePath;


            }


            return View("../Image/ImageUpload");
        }
    }
}
        
