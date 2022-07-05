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