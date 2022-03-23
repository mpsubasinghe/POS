using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;

namespace MiddleLayer
{
    public class Setting : ISetting
    {
        public string SettingID { get; set; }
        public string SettingValue { get; set; }
    }
}
