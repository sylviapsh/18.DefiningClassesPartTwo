using System;

namespace TaskEleven
{
    [VersionAttribute(12, 6)]
    class VersionTestProgram
    {
        static void Main(string[] args)
        {
            try
            {
                Type type = typeof(VersionTestProgram);
                object[] allAttributes = type.GetCustomAttributes(false);
                foreach (VersionAttribute versionAttribute in allAttributes)
                {
                    Console.WriteLine("The version of the class is {0} ", versionAttribute);
                }
            }

            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore);
            }
        }
    }
}
