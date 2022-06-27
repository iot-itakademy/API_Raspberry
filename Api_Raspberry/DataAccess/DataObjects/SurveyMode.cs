using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class SurveyMode
    {
        public int Id { get; set; }
        public string Params { get; set; } = null!;
        public int LastEditBy { get; set; }
    }
}
