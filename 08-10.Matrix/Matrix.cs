using System;
using System.Text;

namespace TasksEightToTen
{
    public class Matrix<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>, new()
    {
        //Fields
        private int rows;
        private int columns;
        private T[,] matrix;

        
        //Properties  
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public T[,] MatrixProp
        {
            get { return matrix; }
            set { matrix = value; }
        }
        
        //Constructors
        public Matrix() : this(0, 0, new T[0, 0]) {}

        public Matrix(int _rows, int _columns) : this(_rows, _columns, new T[_rows, _columns]) { }

        public Matrix(int _rows, int _columns, T[,] _matrix)
        {
            this.Rows = _rows;
            this.Columns = _columns;
            this.MatrixProp = _matrix;
        }

        //Indexer
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > this.rows || j > this.columns)
                {
                    throw new IndexOutOfRangeException("There is no element with such an index!");
                }
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }

        //Override ToString()
        public override string ToString()
        {
            StringBuilder printMatrix = new StringBuilder();
            printMatrix.AppendLine("---------------------");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    printMatrix.AppendLine(String.Format("[{0},{1}] = {2}", i, j, MatrixProp[i, j]));
                }
                printMatrix.AppendLine();
            }
            printMatrix.AppendLine("---------------------");

            return printMatrix.ToString();
        }

        //Plus operator
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new FormatException("Addition with the plus sign (+) cannot be applyed on matrices with different dimensions!");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
                for (int i = 0; i < firstMatrix.Rows; i++)
                {
                    for (int j = 0; j < firstMatrix.Columns; j++)
                    {
                        resultMatrix.matrix[i, j] = (dynamic)firstMatrix.matrix[i, j] + (dynamic)secondMatrix.matrix[i, j];
                    }
                }
                return resultMatrix;
            }
        }

        //Minus operator
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new FormatException("Substraction with the minus sign (-) cannot be applyed on matrices with different dimensions!");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
                for (int i = 0; i < firstMatrix.Rows; i++)
                {
                    for (int j = 0; j < firstMatrix.Columns; j++)
                    {
                        resultMatrix.matrix[i, j] = (dynamic)firstMatrix.matrix[i, j] - (dynamic)secondMatrix.matrix[i, j];
                    }
                }
                return resultMatrix;
            }
        }

        //Multiplication operator
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Columns != secondMatrix.Rows)
            {
                throw new FormatException("Multiplication with the multiplication sign (*) cannot be used on matrixes with dimensions that have different row and column sizes!");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);

                for (int i = 0; i < firstMatrix.Rows; i++)
                {
                    for (int j = 0; j < secondMatrix.Columns; j++)
                    {
                        dynamic sum = 0;
                        for (int k = 0; k < secondMatrix.Columns; k++)
                        {
                            sum += (dynamic)firstMatrix.matrix[i, k] * (dynamic)secondMatrix.matrix[k, j];
                        }
                        resultMatrix.matrix[i, j] = sum;
                    }
                }

                return resultMatrix;
            }
        }

        //Implement the true operator (checks for non-zero elements).
        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    int zero = 0;
                    if (matrix[i, j].CompareTo((T)Convert.ChangeType(zero, typeof(T))) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j].CompareTo(new T()) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
