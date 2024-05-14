using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImgStorgeASP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImgStorgeASP.Controllers
{
    public class UploadController : Controller
    {
        // GET: /Upload/
        [HttpGet("upload")]
        public IActionResult Index()
        {
            return View();
        }

        private bool IsImageFile(IFormFile file)
        {
            // Check if the file content type starts with "image/"
            return file.ContentType.StartsWith("image/");
        }

        // POST: /Upload/Image
        [HttpPost("upload/image")]
        public async Task<IActionResult> UploadImage(UploadModel model)
        {
            //check if noting was uploaded
            if (model.Image == null || model.Image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (!IsImageFile(model.Image))
            {
                BadRequest("Uploaded object is not an image file"); 
            }

            string folderPath = $"./json_{model.Path.Trim()}"; //trim to remove whitespaces

            if (string.IsNullOrEmpty(folderPath))
            {
                return BadRequest("Invalid path specified.");
            }

            string filePath = Path.Combine($"./json_{model.Path}",$"{model.Path}.png");

            Console.WriteLine($"FILENAME : {filePath}");

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); //create if does not exist

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);     //saving image inside choosen folder
            }

            return Ok("File uploaded successfully.");
        }
    }
}