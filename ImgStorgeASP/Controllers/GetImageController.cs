using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImgStorgeASP.Models
{
    [ApiController]
    public class GetImageController : Controller
    {
        [HttpGet("{image_name}")]
        public IActionResult GetImage(string image_name)
        {
            // Construct the file path based on the image_name
            string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}/json_{image_name}/", $"{image_name}.png");

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); 
            }

            // Return the image file as a physical file result
            return PhysicalFile(filePath, "image/png"); 
        }

    }
}

