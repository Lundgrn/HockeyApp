using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HockeyApp
{
    [DebuggerDisplay("{Day}, {WeekDay}, {Month}")]
    class Game       
    {
        public string Month { get; set; }
        public string WeekDay { get; set; }
        public string Day { get; set; } 

    }   
}
