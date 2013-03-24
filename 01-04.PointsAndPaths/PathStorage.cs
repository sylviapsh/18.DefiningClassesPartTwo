using System;
using System.Collections.Generic;
using System.IO;

// Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

namespace TasksOneToFour
{
    public static class PathStorage
    {
        //Method to save paths in a txt file
        public static void SavePath(Path path)
        {
            using (StreamWriter writePath = new StreamWriter(@"../../SavedPaths.txt",true))
            {
                foreach (Point3D point in path.Paths)
                {
                    writePath.WriteLine(point);
                }
                writePath.WriteLine("***");
            }
        }

        public static List<Path> LoadPath()
        {
            Path loadPath = new Path();
            List<Path> loadedPaths = new List<Path>();
            using (StreamReader readPath = new StreamReader(@"../../SavedPaths.txt"))
            {
                string readLine = readPath.ReadLine();
                while (readLine != null)
                {
                    if (readLine != "***")
                    {
                        Point3D point = new Point3D();
                        char[] splitChars = new char[]{ ',', '(', ')'};
                        string[] points = readLine.Split(splitChars,StringSplitOptions.RemoveEmptyEntries);
                        point.X = int.Parse(points[0]);
                        point.Y = int.Parse(points[1]);
                        point.Z = int.Parse(points[2]);
                        loadPath.AddPoint(point);
                    }
                    else
                    {
                        loadedPaths.Add(loadPath);
                        loadPath = new Path();
                    }

                    readLine = readPath.ReadLine();
                }
            }
            return loadedPaths;
        }
    }
}
