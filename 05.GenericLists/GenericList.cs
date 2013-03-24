using System;
using System.Collections.Generic;
using System.Text;

//Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.

namespace TasksFiveToSeven
{
    public class GenericList<T> 
        where T : IComparable,  new()

    {
        private int index = 0;
        private T[] list;

        public T[] List
        {
            get { return list; }
            set { list = value; }
        }

        //Constructor with fixed capacity
        public GenericList(int capacity)
        {
            this.List = new T[capacity];
        }

        //Constructor with default capacity of 5 elements
        public GenericList() : this(5) {}

        //Add element method
        public void AddElement(T value)
        {
            if (index == List.Length)
            {
               List = EnsureCapacity();
            }
            List[index] = value;
            index++;
        }

        //Ensure capacity method
        private T[] EnsureCapacity()
        {
            T[] extendedArray = new T[List.Length * 2];
            for (int i = 0; i < List.Length; i++)
            {
                extendedArray[i] = List[i];
            }

            return extendedArray;
        }

        //Accessing element by index
        public T GetElementAtIndex(int indexOfElement)
        {
            if (indexOfElement > index - 1 || indexOfElement < 0)
            {
                throw new IndexOutOfRangeException("The entered index of element doesn't exist in the array!");
            }
            return this.List[indexOfElement];
        }

        //Removing element by index
        public void RemoveElementAtIndex(int indexOfElement)
        {
            if (indexOfElement < 0 || indexOfElement >= index)
            {
                throw new IndexOutOfRangeException("The element cannot be removed because the entered index of element doesn't exist in the array!");
            }
            else
            {
                T[] removedElementArray = new T[List.Length];

                for (int i = 0; i < indexOfElement; i++)
                {
                    removedElementArray[i] = List[i];
                }

                for (int i = indexOfElement + 1; i < index; i++)
                {
                    removedElementArray[i - 1] = List[i];
                }

                List = removedElementArray;
                index--;
            }
        }

        //Inserting element by index
        public void InsertElementAtIndex(int indexOfElement, T value)
        {
            if (indexOfElement == List.Length)
            {
                EnsureCapacity();
            }

            if (indexOfElement < 0 || indexOfElement > index)
            {
                throw new IndexOutOfRangeException("The element cannot be inserted because the entered index of element doesn't exist in the array!");
            }
            else
            {
                T[] insertedElemArray = new T[List.Length + 1];

                for (int i = 0; i < indexOfElement; i++)
                {
                    insertedElemArray[i] = List[i];
                }

                insertedElemArray[indexOfElement] = value;

                for (int i = indexOfElement; i < index; i++)
                {
                    insertedElemArray[i+1] = List[i];
                }

                List = insertedElemArray;
                index++;
            }
        }

        //Clear the list
        public void ClearList()
        {
            List = new T[4];
            index = 0;
        }

        //Ovveride ToString()
        public override string ToString()
        {
            StringBuilder printList = new StringBuilder();

            printList.AppendLine("List elements: ");

            for (int i = 0; i < index; i++)
            {
                printList.AppendLine(String.Format("Index {0} = {1}", i, list[i]));
            }

            return printList.ToString();
        }

        //Find element by value method. Returns -1 if nothing is found
        public int FindElement(T value)
        {
            int indexOfFoundElem = -1;

            for (int i = 0; i < index; i++)
            {
                if (value.Equals(List[i]))
                {
                    return i;
                }
            }

            return indexOfFoundElem;
        }

        //Indexer
        public T this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer >= index)
                {
                    throw new IndexOutOfRangeException("The index doesn't exist!");
                }
                else
                {
                    return List[indexer];
                }
            }
            set
            {
                if (indexer < 0 || indexer >= index)
                {
                    throw new IndexOutOfRangeException("The index doesn't exist!");
                }
                else
                {
                    List[indexer] = value;
                }
            }
        }

        //Minimum element in list
        public T MinElement()
        {
            T minElement = List[0];

            for (int i = 0; i < index; i++)
            {
                if ((dynamic)minElement > (dynamic)list[i])
                {
                    minElement = List[i];
                }
            }

            return minElement;
        }

        //Maximum element in list
        public T MaxElement()
        {
            T maxElement = List[0];

            for (int i = 0; i < index; i++)
            {
                if ((dynamic)maxElement < (dynamic)list[i])
                {
                    maxElement = List[i];
                }
            }

            return maxElement;
        }
    }
}
