using Microsoft.AspNetCore.Mvc;
using Api_Raspberry.Entity.Files;

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
    }
}
