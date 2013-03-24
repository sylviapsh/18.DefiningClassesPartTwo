using System;
using System.Collections.Generic;

namespace TasksFiveToSeven
{
    class GenericListTestProgram
    {
        static void Main()
        {
            //Create generic list
            GenericList<int> myList = new GenericList<int>(2);

            //Add elemnets
            myList.AddElement(30);
            myList.AddElement(2);
            myList.AddElement(3);

            Console.WriteLine(myList);

            //Access element by index
            Console.Write("The element at index 0 is: ");
            Console.WriteLine(myList.GetElementAtIndex(0));
            Console.WriteLine();

            //Remove element at certain index
            myList.RemoveElementAtIndex(1);
            Console.WriteLine("The element at index 1 has been removed!");
            Console.WriteLine(myList);

            //Insert element at certain index
            myList.InsertElementAtIndex(1, 800);
            Console.WriteLine("The element at index 1 has been inserted!");
            Console.WriteLine(myList);

            //Find index of value 800 and 3000
            Console.Write("The value 800 has index of: ");
            Console.WriteLine(myList.FindElement(800));
            Console.Write("The value 3000 has index of: ");
            Console.WriteLine(myList.FindElement(3000));

            //Min element in list
            Console.WriteLine();
            Console.Write("The min element is:");
            Console.WriteLine(myList.MinElement());

            //Max element in list
            Console.Write("The max element is:");
            Console.WriteLine(myList.MaxElement());
        }
    }
}
