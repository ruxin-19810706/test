using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySstem.Object
{
    public class ChannelParam
    {
        public int AlarmThreshold{ get; set; }
        public int ChannelGain { get; set; }
        //public int Sign1 { get; set; }
        //public int Sign2 { get; set; }
        //public int Sign3 { get; set; }
        public int TX { get; set; }
        public int RX { get; set; }
        public int Buzzer { get; set; }
    }
}
