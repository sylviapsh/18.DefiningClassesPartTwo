using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

namespace TaskEleven
{
    [AttributeUsage
        (AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Method |
        AttributeTargets.Enum)]

    class VersionAttribute : System.Attribute
    {
        private int majorVersion;
        private int minorVersion;

        
        public int MajorVersion
        {
            get { return majorVersion; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The major version cannot be a negative number!");
                }
                majorVersion = value; 
            }
        }

        public int MinorVersion
        {
            get { return minorVersion; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The minor version cannot be a negative number!");
                }
                minorVersion = value; 
            }
        }

        public VersionAttribute(int majorVer, int minorVer)
        {
            this.MajorVersion = majorVer;
            this.MinorVersion = minorVer;
        }

        //Ovveride ToString()
        public override string ToString()
        {
            return String.Format("{0}.{1}", MajorVersion, MinorVersion).ToString();
        }
    }
}
