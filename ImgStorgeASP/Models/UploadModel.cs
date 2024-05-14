using System;
namespace ImgStorgeASP.Models
{
	public class UploadModel
	{
        public IFormFile Image { get; set; }
        public string Path { get; set; }
    }
}

