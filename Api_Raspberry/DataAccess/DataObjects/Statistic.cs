using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
