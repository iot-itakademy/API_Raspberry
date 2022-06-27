using Microsoft.AspNetCore.Mvc;
using Api_Raspberry.DataAccess.DataObjects;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        iot_akademyContext db = new iot_akademyContext();

        /// <summary>
        /// Get camera params by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON</returns>
        [HttpGet("{id}")]
        public Array GetCameraParamsById(int id)
        {
            List<Sensor> result = new List<Sensor>();
            foreach (var settings in db.Sensors.Where(s => s.Id == id))
            {
                result.Add(settings);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Get global settings for the project
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        public Array GetGlobalSettings()
        {
            return db.GlobalSettings.Where(s => s.Id == 1).ToArray();
        }
    }
}
