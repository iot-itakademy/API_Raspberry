using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class Badge
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? Token { get; set; }
        public virtual User User { get; set; }
    }
}
