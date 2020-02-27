using System;

namespace DistanceCalulator
{
    public static class DistanceCalculator
    {
        private const double earthRadiusKm = 6371;
        private const double earthRadiusMi = 3958.8;


        public static double GetKilometers(Position pos1, Position pos2) =>
            Math.Round(earthRadiusKm * GetDistance(pos1, pos2), 3);

        public static double GetMiles(Position pos1, Position pos2) =>
            Math.Round(earthRadiusMi * GetDistance(pos1, pos2), 3);


        private static double GetDistance(Position pos1, Position pos2)
        {
            // Calculation based on https://andrew.hedges.name/experiments/haversine/ (2020-02-27)

            double dLon = DegreesToRadius(pos2.Longitude - pos1.Longitude);
            double dLat = DegreesToRadius(pos2.Latitude - pos1.Latitude);

            var a =
                Math.Pow(Math.Sin(dLat / 2), 2) +
                Math.Cos(DegreesToRadius(pos1.Latitude)) *
                Math.Cos(DegreesToRadius(pos2.Latitude)) *
                Math.Pow(Math.Sin(dLon / 2), 2);

            return 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private static double DegreesToRadius(double deg) =>
            deg * (Math.PI / 180);
    }
}
