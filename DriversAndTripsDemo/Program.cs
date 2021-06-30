using System;
using System.Collections.Generic;
using System.Linq;
using static DriversAndTripsDemo.Utilities;
namespace DriversAndTripsDemo
{
     class Program
     {
          static void Main(string[] args)
          {
               List<AutoDriver> DriversList = new List<AutoDriver>();     //collection of auto drivers
               List<Trips> TripsList = new List<Trips>();                 //collectiono of trips

               //Get data:
               //Fetches data from the file
               //Parses into the corresponding drivers, trips object collection
               //Each corresponding trip object perfomr the needed calculations
               Utilities.GetData(ref DriversList, ref TripsList);

               //Report
               Reports.TripsByDriverReport(ref DriversList, ref TripsList);

          }
     }
}
