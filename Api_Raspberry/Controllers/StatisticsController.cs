using Api_Raspberry.DataAccess.DataObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        iot_akademyContext db = new iot_akademyContext();

        /// <summary>
        /// Route used to send statistics from the raspberry when a detection is made
        /// </summary>
        /// <param name="stat"></param>
        [HttpPost]
        [Route("post")]
        public void AddStatistics(Statistic stat)
        {
            if (stat != null && stat.Type != "string" && stat.Date != null && stat.Amount != 0)
            {
                db.Statistics.Add(stat);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Return all the statistics from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public Array GetStatistics()
        {
            List<Microsoft.EntityFrameworkCore.DbSet<Statistic>> statistics = new List<Microsoft.EntityFrameworkCore.DbSet<Statistic>>();
            statistics.Add(db.Statistics);

            return statistics[0].ToArray();
        }
    }
}