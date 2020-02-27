using System;

namespace DistanceCalulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distance Calculator");
            Console.WriteLine("-------------------");

            var pos1 = new Position();
            Console.Write("Latitude 1: ");
            pos1.Latitude = ReadDouble();
            Console.Write("Longitude 1: ");
            pos1.Longitude = ReadDouble();

            var pos2 = new Position();
            Console.Write("Latitude 2: ");
            pos2.Latitude = ReadDouble();
            Console.Write("Longitude 2: ");
            pos2.Longitude = ReadDouble();

            Console.WriteLine("-------------------");

            var miles = DistanceCalculator.GetMiles(pos1, pos2);
            var kilometers = DistanceCalculator.GetKilometers(pos1, pos2);

            Console.WriteLine($"{miles} miles");
            Console.WriteLine($"{kilometers} km");

            Console.ReadLine();
        }

        static double ReadDouble()
        {
            double? result = null;

            while (result == null)
            {
                string value = Console.ReadLine();

                try
                {
                    value = value.Replace('.', ',').Trim();
                    result = double.Parse(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Try again: ");
                }
            }

            return result.Value;
        }
    }
}
