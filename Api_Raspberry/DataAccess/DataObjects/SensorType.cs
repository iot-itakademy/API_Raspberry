using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class SensorType
    {
        public SensorType()
        {
            Sensors = new HashSet<Sensor>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
