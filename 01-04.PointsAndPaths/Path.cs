using System;
using System.Collections.Generic;

namespace TasksOneToFour
{
    //Create a class Path to hold a sequence of points in the 3D space.

    public class Path
    {
        public List<Point3D> pathPoints = new List<Point3D>();

        public List<Point3D> Paths
        {
            get
            {
                return this.pathPoints;
            }
        }

        //Method to add a point
        public void AddPoint(Point3D point)
        {
            pathPoints.Add(point);
        }

        //Method to clear Paths
        public void ClearPath()
        {
            pathPoints.Clear();
        }
    }
}
