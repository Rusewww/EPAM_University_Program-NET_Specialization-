using System;

namespace MatrixLibrary
{
    public class MatrixException : Exception
    {
        public MatrixException() : base() { }

        public MatrixException(string message) : base(message) { }

        public MatrixException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class Matrix : ICloneable
    {
        private readonly double[,] _array;
        private readonly int _rows;
        private readonly int _columns;

        public int Rows => _rows;

        public int Columns => _columns;

        public double[,] Array
        {
            get
            {
                double[,] result = new double[_rows, _columns];
                System.Array.Copy(_array, result, _rows * _columns);
                return result;
            }
        }

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new MatrixException("Matrix dimensions must be positive.");
            }

            _rows = rows;
            _columns = columns;
            _array = new double[rows, columns];
        }

        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            _rows = array.GetLength(0);
            _columns = array.GetLength(1);
            _array = new double[_rows, _columns];
            System.Array.Copy(array, _array, _rows * _columns);
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= _rows || column < 0 || column >= _columns)
                {
                    throw new MatrixException("Invalid matrix index.");
                }

                return _array[row, column];
            }
            set
            {
                if (row < 0 || row >= _rows || column < 0 || column >= _columns)
                {
                    throw new MatrixException("Invalid matrix index.");
                }

                _array[row, column] = value;
            }
        }

        public object Clone()
        {
            Matrix result = new Matrix(_rows, _columns);
            System.Array.Copy(_array, result._array, _rows * _columns);
            return result;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix1._rows != matrix2._rows || matrix1._columns != matrix2._columns)
            {
                throw new MatrixException("Matrix dimensions must be equal.");
            }

            Matrix result = new Matrix(matrix1._rows, matrix1._columns);

            for (int i = 0; i < result._rows; i++)
            {
                for (int j = 0; j < result._columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix1._rows != matrix2._rows || matrix1._columns != matrix2._columns)
            {
                throw new MatrixException("Matrix dimensions must be equal.");
            }

            Matrix result = new Matrix(matrix1._rows, matrix1._columns);

            for (int i = 0; i < result._rows; i++)
            {
                for (int j = 0; j < result._columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix1._columns != matrix2._rows)
            {
                throw new MatrixException("Invalid matrix dimensions for multiplication.");
            }

            Matrix result = new Matrix(matrix1._rows, matrix2._columns);

            for (int i = 0; i < result._rows; i++)
            {
                for (int j = 0; j < result._columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < matrix1._columns; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (Columns != matrix.Rows)
            {
                throw new MatrixException("Invalid matrix dimensions for multiplication.");
            }

            Matrix result = new Matrix(Rows, matrix.Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Columns; k++)
                    {
                        sum += this[i, k] * matrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (_rows != matrix._rows || _columns != matrix._columns)
            {
                throw new MatrixException("Matrix dimensions must be equal.");
            }

            Matrix result = new Matrix(_rows, _columns);

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    result._array[i, j] = _array[i, j] + matrix._array[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            if (Rows != matrix.Rows || Columns != matrix.Columns)
                throw new MatrixException("The matrices must have the same dimensions.");

            var result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] - matrix[i, j];
                }
            }

            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Matrix))
            {
                return false;
            }

            Matrix other = (Matrix)obj;

            if (this.Rows != other.Rows || this.Columns != other.Columns)
            {
                return false;
            }

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
