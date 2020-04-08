using System;
using System.Collections.Generic;
using System.Text;

namespace DT_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример из лекции\n{0}", "x1*x1 - x1*x2 + 3*x2*x2 - x1");
            HJAlgorithm algorithm = new HJAlgorithm(function_test_var, new SPoint(new double[] { 0, 0 }));
            Console.WriteLine(algorithm.minValue());
            
            Console.WriteLine();
            
            Console.WriteLine("Вариант 1\n{0}", "3*x1*x1 + x1*x2 + 3*x2*x2 - 8*x1");
            HJAlgorithm var_1_algorithm = new HJAlgorithm(function_var_1, new SPoint(new double[] { 1, 2 }));
            Console.WriteLine(var_1_algorithm.minValue());
            
            Console.WriteLine();
            
            Console.WriteLine("Вариант 2\n{0}", "x1*x1*x1*x1 + x1*x1*x2 - 6*x1*x1 -1,2*x1*x2 +x2*x2");
            HJAlgorithm var_2_algorithm = new HJAlgorithm(function_var_2, new SPoint(new double[] { 1, 2 }));
            Console.WriteLine(var_2_algorithm.minValue());
            
            Console.WriteLine();
            
            Console.WriteLine("Вариант 5\n{0}", "3*x1*x1 - 3*x1*x2 + 2*x2*x2 + x1 - 7*x2");
            HJAlgorithm var_5_algorithm = new HJAlgorithm(function_var_5, new SPoint(new double[] { -2, 1 }));
            Console.WriteLine(var_5_algorithm.minValue());
            
            Console.WriteLine();
            
            Console.WriteLine("Вариант 4\n{0}", "4*x1*x1+ 4*x2*x2 + x3*x3 - 2*x1*x3 - 5*x1*x2 - 8*x3");
            HJAlgorithm var_4_algorithm = new HJAlgorithm(function_var_4, new SPoint(new double[] { 1, 1, 1 }));
            Console.WriteLine(var_4_algorithm.minValue());

            Console.ReadKey();
        }

        static double function_test_var(SPoint point)
        {
            return point.coordinates[0] * point.coordinates[0] - point.coordinates[0] * point.coordinates[1] +
                    3 * point.coordinates[1] * point.coordinates[1] - point.coordinates[0];
        }

        static double function_var_1(SPoint point)
        {
            return 3 * point.coordinates[0] * point.coordinates[0] + point.coordinates[0] * point.coordinates[1] +
                    3 * point.coordinates[1] * point.coordinates[1] - 8 * point.coordinates[0];
        }

        static double function_var_2(SPoint point)
        {
            return point.coordinates[0] * point.coordinates[0] * point.coordinates[0] * point.coordinates[0] +
                    point.coordinates[0] * point.coordinates[0] * point.coordinates[1] -
                    6 * point.coordinates[0] * point.coordinates[0] -
                    1.2 * point.coordinates[0] * point.coordinates[1] +
                    point.coordinates[1] * point.coordinates[1];
        }

        static double function_var_5(SPoint point)
        {
            return 3 * point.coordinates[0] * point.coordinates[0] -
                    3 * point.coordinates[0] * point.coordinates[1] +
                    2 * point.coordinates[1] * point.coordinates[1] +
                    point.coordinates[0] - 7 * point.coordinates[1];
        }

        static double function_var_4(SPoint point)
        {
            return 4 * point.coordinates[0] * point.coordinates[0] +
                    4 * point.coordinates[1] * point.coordinates[1] +
                    point.coordinates[2] * point.coordinates[2] -
                    2 * point.coordinates[0] * point.coordinates[2] -
                    5 * point.coordinates[0] * point.coordinates[1] -
                    8 * point.coordinates[2];
        }
    }
}
