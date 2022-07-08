using Microsoft.AspNetCore.Mvc;
using Api_Raspberry.Entity.Files;
using System;
using System.IO;

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        protected readonly IConfiguration _configuration;

        public FileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Return every images in the folder security from the raspberry.
        /// </summary>
        /// <returns></returns>
        [HttpGet("images")]
        public Array GetImagesFromDirectory()
        {
            List<Image> base64Array = new List<Image>();
            string[] images = Directory.GetFiles(_configuration.GetValue<string>("Configuration:ImageUrl"));
            foreach (var image in images)
            {
                using(var reader = new FileStream(image, FileMode.Open))
                {
                    byte[] buffer = new byte[reader.Length];
                    reader.Read(buffer, 0, (int)buffer.Length);
                    Image obj = new Image();
                    obj.fileName = Path.GetFileName(image);
                    obj.base64Image = Convert.ToBase64String(buffer);
                    base64Array.Add(obj);
                }
            }

            return base64Array.ToArray();
        }

        /// <summary>
        /// Return every namefile in the folder security from the raspberry
        /// </summary>
        /// <returns></returns>
        [HttpGet("images/name")]
        public Array GetImageFileName()
        {
            List<string> imagesName = new List<string>();
            string[] images = Directory.GetFiles(_configuration.GetValue<string>("Configuration:ImageUrl"));
            foreach (var image in images)
            {
                imagesName.Add(Path.GetFileName(image));
            }

            return imagesName.ToArray();
        }

        /// <summary>
        /// Return every images from the year and month that was send in the body
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("images/{year}/{month}")]
        public Array GetImagesByDate(string month, string year)
        {
            List<Image> imagesList = new List<Image>();
            string wanted = year + "-" + month;
            string[] images = Directory.GetFiles(_configuration.GetValue<string>("Configuration:ImageUrl"));

            foreach (var image in images)
            {
                if (image.Contains(wanted)){
                    using (var reader = new FileStream(image, FileMode.Open))
                    {
                        byte[] buffer = new byte[reader.Length];
                        reader.Read(buffer, 0, (int)buffer.Length);
                        Image obj = new Image();
                        obj.fileName = Path.GetFileName(image);
                        obj.base64Image = Convert.ToBase64String(buffer);
                        imagesList.Add(obj);
                    }
                }
            }

            return imagesList.ToArray();
        }

        /// <summary>
        /// Delete file in the folder security
        /// </summary>
        [HttpDelete("images/delete")]
        public void deleteFile([FromBody] Image image)
        {
            if (System.IO.File.Exists(_configuration.GetValue<string>("Configuration:ImageUrl") + "/" + image.fileName))
            {
                System.IO.File.Delete(_configuration.GetValue<string>("Configuration:ImageUrl") + "/" + image.fileName);
            }
        }
    }
}
