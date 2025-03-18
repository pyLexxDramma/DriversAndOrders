using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DriversAndOrders
{
    public class Order
    {
        public int OrderId { get; set; }
        public string DriverFullName { get; set; }
        public string DriverLicense { get; set; }
        public string CarBrandAndModel { get; set; }
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime StartTime { get; set; }
        public bool Status { get; set; }
    }
}