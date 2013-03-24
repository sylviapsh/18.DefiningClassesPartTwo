using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksOneToFour
{
    //Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

   public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

      

       //Constructor
        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

       //Static field
        private static readonly Point3D coordinateSystemStart = new Point3D(0, 0, 0);

       //Static Property
        public static Point3D CoordinateSystemStart
        {
            get { return coordinateSystemStart; }
        }

        //Printing a 3D point
        public override string ToString()
        {
           string point = String.Format("({0}, {1}, {2})", X, Y, Z );
           return point;
        }  
    }
}
