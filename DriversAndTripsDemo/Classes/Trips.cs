using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversAndTripsDemo
{
     public class Trips
     {
          public int id { get; set; }
          public int DriverId { get; set; }
          public DateTime TripStart { get; set; }
          public DateTime TripEnd { get; set; }
          public decimal TripDuration { get; set; }
          public decimal TripMiles { get; set; }
          public decimal Speed { get; set; }

          public Trips(int tripid, int driverid, DateTime tripStart, DateTime tripEnd, decimal miles)
          {
               this.id = tripid;
               this.DriverId = driverid;
               this.TripStart = tripStart;
               this.TripEnd = tripEnd;
               //this.TripDuration = this.TripEnd.Subtract(this.TripStart);  // this.TripEnd - this.TripStart;
               TimeSpan ts = this.TripEnd.Subtract(this.TripStart);  
               this.TripDuration = (ts.Hours * 60) + ts.Minutes;
               this.TripMiles = miles;
               //(miles/minutes)*60
               this.Speed = Math.Round( (this.TripMiles / this.TripDuration )*60,1);
          }
     }
}
