using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
