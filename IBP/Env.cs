using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBP
{
    public class Z1Y
    {
        public string url { get; set; }
        public IList<string> plant_name { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string id { get; set; }
        public string Password { get; set; }
    }

    public class ZSB
    {
        public string url { get; set; }
        public IList<string> plant_name { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string id { get; set; }
        public string Password { get; set; }
    }

    public class Env
    {
        public Z1Y Z1Y { get; set; }
        public ZSB ZSB { get; set; }
    }


}
