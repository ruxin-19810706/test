using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySstem.Object
{
    public class SystemParam
    {
        public int Phase { get; set; }
        public int Frequency { get; set; }
        public int SendInterval { get; set; }
        public int SendStrength { get; set; }
        public int RevDelay { get; set; }
        public int ChannelMode { get; set; }
        public int InterferenceDetection { get; set; }
        public int SignDetection { get; set; }
        public int DecodingFilterA { get; set; }
        public int DecodingFilterB { get; set; }
        public int DecodingFilterC { get; set; }
        public int DecodingFilterD { get; set; }
    }
}
