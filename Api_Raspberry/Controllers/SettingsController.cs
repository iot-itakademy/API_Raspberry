using Microsoft.AspNetCore.Mvc;
using Api_Raspberry.DataAccess.DataObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        iot_akademyContext db = new iot_akademyContext();
        // GET: api/<SettingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/<SettingsController>/camera/<id>
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

        // POST api/<SettingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SettingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
