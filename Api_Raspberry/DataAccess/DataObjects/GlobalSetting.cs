using System;
using System.Collections.Generic;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class GlobalSetting
    {
        public int Id { get; set; }
        public int SurveyModeId { get; set; }
        public string TimeZone { get; set; } = null!;
        public int LastEditBy { get; set; }
    }
}
