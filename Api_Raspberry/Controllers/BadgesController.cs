using Api_Raspberry.DataAccess.DataObjects;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        iot_akademyContext db = new iot_akademyContext();

        /// <summary>
        /// Get RFID badge and user when scanned
        /// </summary>
        /// <returns></returns>
        [HttpGet("token")]
        public Boolean GetBadgeByRFID(int token)
        {
            bool access = false;
            if (db.Badges.Where(b => b.Token == token).FirstOrDefault() != null)
            {
                access = true;
            } 
            else
            {
                access = false;
            }

            return access;
        }

        // POST api/<BadgesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BadgesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BadgesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
