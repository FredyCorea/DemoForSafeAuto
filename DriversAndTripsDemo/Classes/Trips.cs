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
          public TimeSpan TripDuration { get; set; }
          public decimal TripMiles { get; set; }
          public decimal Speed { get; set; }

          public Trips(int tripid, int driverid, DateTime tripStart, DateTime tripEnd, decimal miles)
          {
               this.id = tripid;
               this.DriverId = driverid;
               this.TripStart = tripStart;
               this.TripEnd = tripEnd;
               this.TripDuration = this.TripEnd.Subtract(this.TripStart);  // this.TripEnd - this.TripStart;
               this.TripMiles = miles;
               this.Speed = Math.Round( (this.TripMiles / ((this.TripDuration.Hours*60) + this.TripDuration.Minutes))*60,1);
          }
     }
}
