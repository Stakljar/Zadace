using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Description
    {
        int number;
        TimeSpan duration;
        string name;
        public Description() : this(0, new TimeSpan(0, 0, 0), "")
        {
        }
        public Description(int number, TimeSpan duration, string name)
        {
            this.number = number;
            this.duration = duration;
            this.name = name;
        }
        public override string ToString()
        {
            return $"{number},{duration},{name}";
        }

    }
}
