using System;
using System.Collections.Generic;

namespace TasksOneToFour
{
    class PointTestProgram
    {
        static void Main()
        {
            //Create 3 points
            Point3D pointOne = new Point3D(2, 3, 4);
            Point3D pointTwo = new Point3D(0, -3, 10);
            Point3D pointThree = new Point3D(7, -9, -12);

            //Print the points on the console
            Console.WriteLine("Point 1: {0}", pointOne);
            Console.WriteLine("Point 2: {0}", pointTwo);
            Console.WriteLine("Point 3: {0}", pointThree);

            //Calculate the distance between PointOne and PointTwo
            double distance1To2 = Distance3D.Calculate3DDistance(pointOne, pointTwo);
            Console.WriteLine("The distance between point 1 {0} and point 2 {1} is {2:F2}", pointOne, pointTwo, distance1To2);

            //Create 2 paths
            Path pathOne = new Path();
            pathOne.AddPoint(pointOne);
            pathOne.AddPoint(pointThree);

            Path pathTwo = new Path();
            pathTwo.AddPoint(Point3D.CoordinateSystemStart);
            pathTwo.AddPoint(pointTwo);
            pathTwo.AddPoint(pointThree);

            //Save the two paths in a txt file
            PathStorage.SavePath(pathOne);
            PathStorage.SavePath(pathTwo);

            //Load paths
            List<Path> loadedPaths = PathStorage.LoadPath();
            Console.WriteLine("Paths loaded!");
        }
    }
}
