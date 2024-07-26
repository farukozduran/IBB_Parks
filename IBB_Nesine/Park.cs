using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBB_Nesine
{
    public class Park
    {
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public int Capacity { get; set; }
        public int EmptyCapacity { get; set; }
        public string WorkHours { get; set; }
        public string ParkType { get; set; }
        public int FreeTime { get; set; }
        public string District { get; set; }
        public int IsOpen { get; set; }
    }
}
