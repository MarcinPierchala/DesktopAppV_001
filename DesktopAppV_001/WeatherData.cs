﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppV_001
{
    public class WeatherData
    {
        public class weather 
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class root
        {
            public List<weather > weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }

        }
    }
}
