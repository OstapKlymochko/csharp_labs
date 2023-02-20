using System;

namespace csharp_labs// Note: actual namespace depends on the project name.
{
    class Lab1
    {
        static void Main()
        {
            //Task1();
            //Task2(0.5,5,10);
            Task3();
        }
        static double getFractionPart(double num)
        {
            return num - Math.Truncate(num);
        }
        static void Task1()
        {
            //Дано дійсне число n(0<n<1).Перевести його до вісімкової системи числення з точністю до семи вісімкових цифр.
            Console.Write("Введіть число з проміжку (0,1): ");
            if (double.TryParse(Console.ReadLine(), out double num) && num > 0 && num < 1)
            {
                double numCopy = num;
                string res = "";

                for (ushort i = 0; i < 7; ++i)
                {
                    num *= 8;
                    res += Math.Truncate(num);
                    num = getFractionPart(num);
                    if (num == 0.0) break;

                }

                Console.WriteLine($"{numCopy} у вісімковій системі числення: 0.{res}");
                return;
            }
            Console.WriteLine("Невалідне значення :(");
        }
        static void Task2(double x, double y, double z)
        {
            //Дано x, y, z. Обчислити min(max(a, b), c);
            double xyz = z * y * z;
            double sqLgVal = Math.Sqrt(Math.Log10(24));
            double a = (xyz - 3 * Math.Abs(x + Math.Cbrt(y))) / (1000 + sqLgVal); // xyz * 3|x + cbrt(y)|  /  1000 + sqLgVal
            double b = (1000 + sqLgVal) * Math.Sin(xyz) - Math.Cos(xyz) * Math.Cos(xyz); // (1000 + sqLgVal) * sin(xyz) - cos^2(xyz)
            double c = xyz - xyz * xyz * xyz / 6; // xyz - xyz^3 / 3! ;
            Console.WriteLine("Результат: {0}", Math.Max(Math.Min(a, b), c));
        }
        static void Task3()
        {
            // Дано матрицю А:7x5. Утворити і надрукувати вектор b, елементами якого є суми додатніх елементів стовпців матриці А.
            // Знайти номер мінімального елемента вектора b.
            ushort rows = 7;
            ushort cols = 5;
            int[,] matrix = generateMatrix(rows, cols);
            printMatrix(matrix, rows, cols);
            uint[] arr = new uint[7];
            for (ushort i = 0; i < 7; ++i)
            {
                int sum = 0;
                for (ushort j = 0; j < 5; ++j)
                {
                    if (matrix[i, j] > 0) sum += matrix[i, j];
                }
                arr[i] = (uint)sum;
            }
            for (ushort i = 0; i < 7; ++i)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

        }
        static void printMatrix(int[,] arr, ushort rows, ushort cols)
        {
            for (ushort i = 0; i < rows; ++i)
            {
                for (ushort j = 0; j < cols; ++j)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] generateMatrix(uint rows, uint cols)
        {
            Random val = new Random();
            int[,] matrix = new int[rows, cols];
            for (ushort i = 0; i < rows; ++i)
            {
                for (short j = 0; j < cols; ++j)
                {
                    matrix[i, j] = val.Next(-15, 15);
                }
            }
            return matrix;
        }
    }
}