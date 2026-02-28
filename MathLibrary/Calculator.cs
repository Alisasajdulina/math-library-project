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
            // УЛУЧШЕНО: Добавлена проверка на отрицательные числа
            if (number <= 1)
                return false;

            // УЛУЧШЕНО: Оптимизация для четных чисел
            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            // УЛУЧШЕНО: Используем длинный тип для предотвращения переполнения
            long limit = (long)Math.Sqrt(number);

            for (long i = 3; i <= limit; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Возводит число в степень.
        /// </summary>
        public static double Power(double number, double power)
        {
            // УЛУЧШЕНО: Добавлена обработка специальных случаев
            if (power == 0)
                return 1;

            if (number == 0)
                return 0;

            if (double.IsNaN(number) || double.IsInfinity(number))
                throw new ArgumentException("Число не должно быть NaN или бесконечностью");

            return Math.Pow(number, power);
        }

        /// <summary>
        /// Вычисляет факториал числа.
        /// </summary>
        public static long Factorial(int n)
        {
            // УЛУЧШЕНО: Более подробные сообщения об ошибках
            if (n < 0)
                throw new ArgumentException($"Факториал не определен для отрицательных чисел. Получено значение: {n}");

            // УЛУЧШЕНО: Проверка на переполнение
            if (n > 20)
                throw new ArgumentException($"Факториал {n}! слишком велик для типа long. Максимальное значение: 20");

            if (n == 0 || n == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

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
            x1 = null;
            x2 = null;

            // УЛУЧШЕНО: Проверка на вырожденные случаи
            if (a == 0 && b == 0)
            {
                if (c == 0)
                    throw new ArgumentException("Уравнение не определено (0=0)");

                return false; // Нет решений
            }

            // УЛУЧШЕНО: Обработка линейного уравнения
            if (a == 0)
            {
                x1 = -c / b;
                return true;
            }

            double discriminant = b * b - 4 * a * c;

            // УЛУЧШЕНО: Обработка малых значений дискриминанта
            if (Math.Abs(discriminant) < 1e-10)
            {
                x1 = -b / (2 * a);
                return true;
            }

            if (discriminant < 0)
                return false;

            double sqrtD = Math.Sqrt(discriminant);
            double denominator = 2 * a;

            x1 = (-b + sqrtD) / denominator;
            x2 = (-b - sqrtD) / denominator;

            return true;
        }
    }
}