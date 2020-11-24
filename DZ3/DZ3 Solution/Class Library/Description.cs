using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Description
    {
        int lineUpNumber;
        TimeSpan duration;
        string name;
        public Description() : this(0, new TimeSpan(0, 0, 0), "")
        {
        }
        public Description(int lineUpNumber, TimeSpan duration, string name)
        {
            this.lineUpNumber = lineUpNumber;
            this.duration = duration;
            this.name = name;
        }
        public override string ToString()
        {
            return $"{lineUpNumber},{duration},{name}";
        }

    }
}
