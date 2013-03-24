using System;

namespace TasksOneToFour
{
    //Write a static class with a static method to calculate the distance between two points in the 3D space.

    public class Distance3D
    {
        public static double Calculate3DDistance(Point3D point1, Point3D point2)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2) + Math.Pow((point1.Z - point2.Z), 2));

            return distance;
        }
    }
}
