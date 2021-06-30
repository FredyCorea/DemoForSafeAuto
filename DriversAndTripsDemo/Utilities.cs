using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DriversAndTripsDemo
{
     public static class Utilities
     {
          public static void GetData(ref List<AutoDriver> DriversList, ref List<Trips> TripsList)
          {
               String line;
               try
               {
                    StreamReader sr = new StreamReader("C:\\DemoForSafeAuto\\InputData.txt");

                    //Read the first line of text
                    line = sr.ReadLine();
                    {
                         while (line != null)   //Continue to read until you reach end of file
                         {
                              if (line.StartsWith("Driver") == true)
                              {
                                   ParseDriversData(line, ref DriversList);
                              }
                              else if (line.StartsWith("Trip") == true)     //to avoid error if there is an empty line
                              {
                                   ParseTripsData(line, ref DriversList, ref TripsList);
                              }
                              line = sr.ReadLine();    //Read the next line
                         }
                    }

                    sr.Close();    //close the file
               }
               catch (Exception e)
               {
                    Console.WriteLine("");
                    Console.WriteLine("!WARNING!");
                    Console.WriteLine("Error found, please check the log file");
                    Log("Error found " + e.Message.ToString());
               }
               finally
               {
                    Console.WriteLine("");
               }
          }

          private static void ParseDriversData(String pLine, ref List<AutoDriver> DriversList)
          {
               string[] drivers = pLine.Split("Driver");
               for (int i = 0; i <= drivers.Length - 1; i++)
               {
                    if (drivers[i] != "")
                    {
                         AutoDriver a = new AutoDriver(i, drivers[i].ToString().Trim());
                         DriversList.Add(a);
                    }
               }
          }

          private static void ParseTripsData(String pLine, ref List<AutoDriver> pDriversList, ref List<Trips> pTripsList)
          {
               String[] trips = pLine.Split(' ');    // convert trip line to array

               int di = GetDriverId(ref pDriversList, trips[1]);
               DateTime st = Convert.ToDateTime(trips[2]);
               DateTime et = Convert.ToDateTime(trips[3]);
               decimal miles = Decimal.Parse(trips[4]);

               //Crete trip object to add to to collection
               Trips t = new Trips(1, di, st, et, miles);
               pTripsList.Add(t);
          }

          private static int GetDriverId(ref List<AutoDriver> Drivers, string name)
          {
               int di = 0;
               foreach (var item in Drivers)
               {
                    if (item.DriverName == name)
                    {
                         di = item.DriverId;
                         break;
                    }
               }
               return di;
          }

          public static string AddSpaces(string str)
          {
               return string.Concat(Enumerable.Repeat(" ", 10 - str.Length));
          }
                   

          public static void Log(string errorTolog)
          {
               string path = @"C:\DemoForSafeAuto\Log.txt";

               // This text is added only once to the file.
               if (!File.Exists(path))
               {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                         sw.WriteLine(DateTime.Now.ToString());
                         sw.WriteLine(errorTolog);
                    }
               }
               else
               {
                   using (StreamWriter sw = File.AppendText(path))
                    {
                         sw.WriteLine(DateTime.Now.ToString());
                         sw.WriteLine(errorTolog);
                    }
               }
          }
     }
}
