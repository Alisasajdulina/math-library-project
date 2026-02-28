using System;

namespace MathLibrary
{
    /// <summary>
    /// Класс для выполнения математических операций.
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Складывает два числа.
        /// </summary>
        public static double Add(double a, double b) => a + b;

        /// <summary>
        /// Вычитает второе число из первого.
        /// </summary>
        public static double Subtract(double a, double b) => a - b;

        /// <summary>
        /// Умножает два числа.
        /// </summary>
        public static double Multiply(double a, double b) => a * b;

        /// <summary>
        /// Делит первое число на второе.
        /// </summary>
        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Делитель не может быть равен нулю.");

            return a / b;
        }

        /// <summary>
        /// Проверяет, является ли число простым.
        /// </summary>
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int limit = (int)Math.Sqrt(number);

            for (int i = 3; i <= limit; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Возводит число в степень.
        /// </summary>
        public static double Power(double number, double power) =>
            Math.Pow(number, power);

        /// <summary>
        /// Вычисляет факториал числа.
        /// </summary>
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал определен только для неотрицательных чисел.");

            if (n == 0 || n == 1)
                return 1;

            long result = 1;

            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        /// <summary>
        /// Решает квадратное уравнение ax² + bx + c = 0.
        /// </summary>
        public static bool SolveQuadratic(
            double a,
            double b,
            double c,
            out double? x1,
            out double? x2)
        {
            if (a == 0)
                throw new ArgumentException("Коэффициент 'a' не может быть равен 0.");

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                x1 = null;
                x2 = null;
                return false;
            }

            double sqrtD = Math.Sqrt(discriminant);
            double denominator = 2 * a;

            x1 = (-b + sqrtD) / denominator;
            x2 = (-b - sqrtD) / denominator;

            return true;
        }
    }
}