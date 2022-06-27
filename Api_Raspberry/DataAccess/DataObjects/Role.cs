using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
