/*********************************
 * Lab 3                         *
 * Imamov R.R.                   *
 * Data: 26.02.23                *
 ********************************/

using System;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            // Создаем матрицы для тестирования
            var MatrixA = new Matrix(3);
            for (int ColumnCounter = 0; ColumnCounter < 3; ++ColumnCounter)
            {
                for (int RowCounter = 0; RowCounter < 3; ++RowCounter)
                {
                    MatrixA[ColumnCounter, RowCounter] = random.Next(10);
                }
            }
            Console.WriteLine($"MatrixA =\n{MatrixA}");

            var MatrixB = new Matrix(3);
            for (int ColumnCounter = 0; ColumnCounter < 3; ++ColumnCounter)
            {
                for (int RowCounter = 0; RowCounter < 3; ++RowCounter)
                {
                    MatrixB[ColumnCounter, RowCounter] = random.Next(10);
                }
            }
            Console.WriteLine($"MatrixB =\n{MatrixB}");

            // Примеры использования операторов и методов
            Console.WriteLine($"MatrixA + MatrixB =\n{MatrixA + MatrixB}");

            Console.WriteLine($"MatrixA * MatrixB =\n{MatrixA * MatrixB}");

            Console.WriteLine($"MatrixA > MatrixB: {MatrixA > MatrixB}");
            Console.WriteLine($"MatrixA >= MatrixB: {MatrixA >= MatrixB}");
            Console.WriteLine($"MatrixA <= MatrixB: {MatrixA <= MatrixB}");
            Console.WriteLine($"MatrixA == MatrixB: {MatrixA == MatrixB}");
            Console.WriteLine($"MatrixA != MatrixB: {MatrixA != MatrixB}");

            Console.WriteLine($"Determinant of MatrixA: {MatrixA.Determinant()}");

            try
            {
                var inverseA = MatrixA.Inverse();
                Console.WriteLine($"Inverse of MatrixA:\n{inverseA}");
            }
            catch (MatrixNotInvertibleException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Проверка работы прототипа глубокого копирования
            var c = MatrixA.Clone();
            Console.WriteLine($"C =\n{c}");
            Console.WriteLine($"MatrixA == C: {MatrixA == c}");

            // Проверка обработки пользовательских исключений
            try
            {
                var d = new Matrix(0);
            }
            catch (InvalidMatrixSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}