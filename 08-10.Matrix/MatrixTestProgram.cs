using System;

namespace TasksEightToTen
{
    class MatrixTestProgram
    {
        static void Main()
        {
            //Initialize 2 matrices
            Matrix<int> myMatrix1 = new Matrix<int>(2,2);

            myMatrix1[0, 0] = 3;
            myMatrix1[0, 1] = 200;
            myMatrix1[1, 0] = 33;
            myMatrix1[1, 1] = 7000;

            Matrix<int> myMatrix2 = new Matrix<int>(2, 2);

            myMatrix2[0, 0] = 3;
            myMatrix2[0, 1] = 200;
            myMatrix2[1, 0] = 33;
            myMatrix2[1, 1] = 7000;

            Console.WriteLine(myMatrix1);
            Console.WriteLine(myMatrix2);

            //Addition
            Matrix<int> myMatrixAddition = new Matrix<int>();
            myMatrixAddition = myMatrix1 + myMatrix2;
            Console.WriteLine(myMatrixAddition);

            //Substraction
            Matrix<int> myMatrixSubstraction = new Matrix<int>();
            myMatrixSubstraction = myMatrix1 - myMatrix2;
            Console.WriteLine(myMatrixSubstraction);

            //Multiplication
            Matrix<int> myMatrixMultiplication = new Matrix<int>();
            myMatrixMultiplication = myMatrix1 * myMatrix2;
            Console.WriteLine(myMatrixMultiplication);

            //Is the matrix non-zero?
            if (myMatrixSubstraction)
            {
                Console.WriteLine("The matrix is non-zero!");
            }
            else
            {
                Console.WriteLine("The matrix is zero!");
            }
        }
    }
}
