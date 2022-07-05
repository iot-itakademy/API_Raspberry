using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Text;

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("images")]
        public Array GetImagesFromDirectory()
        {
            List<string> base64Array = new List<string>();
            string[] images = Directory.GetFiles("/home/admin/Images/security");
            foreach (var image in images)
            {
                using(var reader = new FileStream(image, FileMode.Open))
                {
                    byte[] buffer = new byte[reader.Length];
                    reader.Read(buffer, 0, (int)buffer.Length);
                    base64Array.Add(Convert.ToBase64String(buffer));
                }
            }

            return base64Array.ToArray();
        }
    }
}
