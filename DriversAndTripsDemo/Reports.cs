using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DriversAndTripsDemo.Utilities;

namespace DriversAndTripsDemo
{
     class Reports
     {

          public static void TripsByDriverReport(ref List<AutoDriver> DriversList, ref List<Trips> TripsList)
          {
               Console.WriteLine("");
               Console.WriteLine("");
               Console.WriteLine("SafeAuto - Drivers Trips Report");

               Console.WriteLine(string.Concat(Enumerable.Repeat("=", 55)));
               Console.WriteLine("");

               //iterate list of objects and create report
               //iterate the drivers list
               foreach (var itemDriver in DriversList)
               {
                    Console.WriteLine("Driver: " + itemDriver.DriverName);

                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 55)));
                    Console.WriteLine("Trip" + AddSpaces("Trip") + "Start" + AddSpaces("Start") + "End" + AddSpaces("End") + "Duration" + AddSpaces("Duration") + "Miles" + AddSpaces("Miles") + "Speed");
                    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 55)));

                    //iterate the trips list
                    int tripCnt = 1;
                    decimal totalMiles = 0;
                    decimal totalTime = 0;
                    decimal totalSpeed = 0;
                    foreach (var itemTrip in TripsList)
                    {
                         if (itemTrip.DriverId == itemDriver.DriverId)
                         {
                              // Console.WriteLine(itemTrip.id.ToString() + "         " + itemTrip.TripStart.ToString("HH:m") + "      " + itemTrip.TripEnd.ToString("HH:m") + "      " + itemTrip.TripDuration.Minutes.ToString() + "          " + itemTrip.TripMiles.ToString() + "       " + itemTrip.Speed.ToString());
                              Console.WriteLine(tripCnt.ToString() + AddSpaces(tripCnt.ToString()) +
                                   itemTrip.TripStart.ToString("HH:m") + AddSpaces(itemTrip.TripStart.ToString("HH:m")) +
                                   itemTrip.TripEnd.ToString("HH:m") + AddSpaces(itemTrip.TripEnd.ToString("HH:m")) +
                                   itemTrip.TripDuration.Minutes.ToString() + AddSpaces(itemTrip.TripDuration.Minutes.ToString()) +
                                   itemTrip.TripMiles.ToString() + AddSpaces(itemTrip.TripMiles.ToString()) + itemTrip.Speed.ToString());

                              tripCnt++;
                              totalMiles = totalMiles + itemTrip.TripMiles;
                              totalTime = totalTime + itemTrip.TripDuration.Minutes;
                              totalSpeed = totalSpeed + itemTrip.Speed;
                         }
                    }

                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 55)));
                    Console.WriteLine("Total Miles                  : " + totalMiles.ToString());
                    Console.WriteLine("Total Driving Time in Minutes: " + totalTime.ToString());
                    Console.WriteLine("Aeverage Speed               : " + (totalSpeed / tripCnt).ToString());
                    Console.WriteLine("");

                    Console.WriteLine("");
               }

               Console.ReadLine();
          }
     }
}

