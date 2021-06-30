using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversAndTripsDemo
{
     public class AutoDriver
     {
          public int DriverId { get; set; }
          public string DriverName { get; set; }

          public AutoDriver(int id,string name)
          {
               this.DriverId = id;
               this.DriverName = name;
          }
     }
}
