using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class Sensor
    {
        public int Id { get; set; }
        public string Params { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }
        public int LastEditBy { get; set; }

        public virtual SensorType Type { get; set; } = null!;
    }
}
