using System;
using MathLibrary;

namespace MathLibrary.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("=== ТЕСТИРОВАНИЕ MathLibrary.dll ===");
            Console.WriteLine("==========================================\n");

            // Тест 1: Арифметические операции
            TestArithmeticOperations();

            // Тест 2: Проверка простых чисел
            TestPrimeNumbers();

            // Тест 3: Дополнительные функции
            TestAdditionalFunctions();

            // Тест 4: Решение квадратных уравнений
            TestQuadraticEquations();

            // Тест 5: Обработка ошибок
            TestErrorHandling();

            Console.WriteLine("\n==========================================");
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void TestArithmeticOperations()
        {
            Console.WriteLine("--- ТЕСТ 1: Арифметические операции ---");
            double x = 10, y = 4;

            Console.WriteLine($"{x} + {y} = {Calculator.Add(x, y)} (Ожидается: 14)");
            Console.WriteLine($"{x} - {y} = {Calculator.Subtract(x, y)} (Ожидается: 6)");
            Console.WriteLine($"{x} * {y} = {Calculator.Multiply(x, y)} (Ожидается: 40)");
            Console.WriteLine($"{x} / {y} = {Calculator.Divide(x, y)} (Ожидается: 2.5)");

            // Тест с другими числами
            double x2 = 15, y2 = 3;
            Console.WriteLine($"\nДополнительно: {x2} / {y2} = {Calculator.Divide(x2, y2)} (Ожидается: 5)");
            Console.WriteLine();
        }

        static void TestPrimeNumbers()
        {
            Console.WriteLine("--- ТЕСТ 2: Проверка простых чисел ---");

            var testCases = new (int Number, bool Expected)[]
            {
                (1, false),    // 1 - не простое
                (2, true),     // 2 - простое
                (3, true),     // 3 - простое
                (4, false),    // 4 - не простое
                (17, true),    // 17 - простое
                (25, false),   // 25 - не простое
                (97, true),    // 97 - простое
                (100, false),  // 100 - не простое
                (997, true)    // 997 - простое
            };

            foreach (var test in testCases)
            {
                bool result = Calculator.IsPrime(test.Number);
                string status = result == test.Expected ? "✓" : "✗";
                Console.WriteLine($"Число {test.Number,3}: {result,-5} (Ожидается: {test.Expected}) {status}");
            }
            Console.WriteLine();
        }

        static void TestAdditionalFunctions()
        {
            Console.WriteLine("--- ТЕСТ 3: Дополнительные функции ---");

            // Тест Power
            Console.WriteLine("Возведение в степень:");
            Console.WriteLine($"2^5 = {Calculator.Power(2, 5),-10} (Ожидается: 32)");
            Console.WriteLine($"3^4 = {Calculator.Power(3, 4),-10} (Ожидается: 81)");
            Console.WriteLine($"5^0 = {Calculator.Power(5, 0),-10} (Ожидается: 1)");
            Console.WriteLine($"2^(-2) = {Calculator.Power(2, -2),-10:F3} (Ожидается: 0.25)");

            // Тест Factorial
            Console.WriteLine("\nФакториал:");
            Console.WriteLine($"0! = {Calculator.Factorial(0),-10} (Ожидается: 1)");
            Console.WriteLine($"5! = {Calculator.Factorial(5),-10} (Ожидается: 120)");
            Console.WriteLine($"10! = {Calculator.Factorial(10),-10} (Ожидается: 3628800)");

            Console.WriteLine();
        }

        static void TestQuadraticEquations()
        {
            Console.WriteLine("--- ТЕСТ 4: Решение квадратных уравнений ---");

            var equations = new (double a, double b, double c, string description)[]
            {
                (1, -3, 2, "x² - 3x + 2 = 0 (два корня)"),
                (1, 2, 1, "x² + 2x + 1 = 0 (один корень)"),
                (2, 1, 3, "2x² + x + 3 = 0 (нет корней)"),
                (0, 2, -4, "2x - 4 = 0 (линейное уравнение)")
            };

            foreach (var eq in equations)
            {
                Console.Write($"{eq.description} -> ");

                bool hasRoots = Calculator.SolveQuadratic(eq.a, eq.b, eq.c, out double? x1, out double? x2);

                if (!hasRoots)
                {
                    Console.WriteLine("нет действительных корней");
                }
                else if (x2 == null)
                {
                    Console.WriteLine($"один корень: x = {x1:F2}");
                }
                else
                {
                    Console.WriteLine($"корни: x1 = {x1:F2}, x2 = {x2:F2}");
                }
            }
            Console.WriteLine();
        }

        static void TestErrorHandling()
        {
            Console.WriteLine("--- ТЕСТ 5: Проверка обработки ошибок ---");

            // Тест деления на ноль
            try
            {
                Console.Write("Попытка деления на ноль: ");
                Calculator.Divide(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"ПЕРЕХВАЧЕНО ИСКЛЮЧЕНИЕ: {ex.Message} ✓");
            }

            // Тест факториала отрицательного числа
            try
            {
                Console.Write("Факториал отрицательного числа (-5): ");
                Calculator.Factorial(-5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ПЕРЕХВАЧЕНО ИСКЛЮЧЕНИЕ: {ex.Message} ✓");
            }

            // Тест факториала слишком большого числа
            try
            {
                Console.Write("Факториал 30 (слишком большое число): ");
                Calculator.Factorial(30);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ПЕРЕХВАЧЕНО ИСКЛЮЧЕНИЕ: {ex.Message} ✓");
            }

            // Тест решения вырожденного уравнения
            try
            {
                Console.Write("Вырожденное уравнение (a=0, b=0, c=0): ");
                Calculator.SolveQuadratic(0, 0, 0, out _, out _);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ПЕРЕХВАЧЕНО ИСКЛЮЧЕНИЕ: {ex.Message} ✓");
            }

            Console.WriteLine("\nВсе исключения успешно перехвачены!");
        }
    }
}