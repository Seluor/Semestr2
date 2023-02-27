using System;

namespace MatrixCalculator
{
    public class InvalidMatrixSizeException : Exception
    {
        public InvalidMatrixSizeException(int size) : base($"Invalid matrix size: {size}")
        {
        }
    }

    public class MatrixNotInvertibleException : Exception
    {
        public MatrixNotInvertibleException() : base("Matrix is not invertible.")
        {
        }
    }
}