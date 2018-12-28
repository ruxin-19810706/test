using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySstem.Object
{
    public class AlarmRecord
    {
        public int index { get; set; }
        public int Number { get; set; }
        public int Code { get; set; }
        public SystemDT RecordDT { get; set; }
        public string Data { get; set; }
       
    }

    public class AlarmComparer : IComparer<AlarmRecord>
    {
        public int Compare(AlarmRecord x, AlarmRecord y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            //TODO：AlarmRecord类实例X与Y的比较规则
            //按Number由小到大排列，Number相同的人Code小的在前
            {
                if (x.index > y.index) return 1;
                if (x.index < y.index) return -1;

              
            }

            return 0;
        }
    }
}
