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
               //Sort the trips list by dirver id + trip miles descending
               var TripsListSorted = from t in TripsList
                                     orderby t.id, t.TripMiles descending
                                     select t;

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

                    //foreach (var itemTrip in TripsList)
                    foreach (var itemTrip in TripsListSorted)
                    {
                         if (itemTrip.DriverId == itemDriver.DriverId)
                         {
                              //Discard any trips that average a speed of less than 5 mph or greater than 100 mph.
                               if (itemTrip.Speed >= 5 && itemTrip.Speed <=100)
                              {
                                   Console.WriteLine(tripCnt.ToString() + AddSpaces(tripCnt.ToString()) +
                                        itemTrip.TripStart.ToString("HH:m") + AddSpaces(itemTrip.TripStart.ToString("HH:m")) +
                                        itemTrip.TripEnd.ToString("HH:m") + AddSpaces(itemTrip.TripEnd.ToString("HH:m")) +
                                        itemTrip.TripDuration.ToString() + AddSpaces(itemTrip.TripDuration.ToString()) +
                                        itemTrip.TripMiles.ToString() + AddSpaces(itemTrip.TripMiles.ToString()) + Math.Round(itemTrip.Speed, 0).ToString() + "mph");

                                   tripCnt++;
                                   totalMiles = totalMiles + itemTrip.TripMiles;
                                   totalTime = totalTime + itemTrip.TripDuration;
                                   totalSpeed = totalSpeed + itemTrip.Speed;
                              }
                         }
                    }

                    decimal avgSpeed = (totalMiles / totalTime) * 60;

                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 55)));
                    Console.WriteLine("Total Miles                  : " + totalMiles.ToString());
                    Console.WriteLine("Total Driving Time in Minutes: " + totalTime.ToString());
                    Console.WriteLine("Average Speed                : " + Math.Round(avgSpeed, 0).ToString() + "mph");
                    Console.WriteLine("");

                    Console.WriteLine("");
               }

               Console.ReadLine();
          }
     }
}

