using System;
using MathLibrary;

Console.WriteLine(" Демонстрация работы MathLibrary.dll \n");

double x = 10, y = 4;

Console.WriteLine($"Сложение: {x} + {y} = {Calculator.Add(x, y)}");
Console.WriteLine($"Вычитание: {x} - {y} = {Calculator.Subtract(x, y)}");
Console.WriteLine($"Умножение: {x} * {y} = {Calculator.Multiply(x, y)}");
Console.WriteLine($"Деление: {x} / {y} = {Calculator.Divide(x, y)}");

try
{
    Calculator.Divide(x, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

Console.WriteLine("\nПроверка чисел на простоту");

int[] numbersToCheck = { 1, 2, 3, 4, 17, 25, 97 };

foreach (int num in numbersToCheck)
{
    Console.WriteLine($"Число {num} простое? -> {Calculator.IsPrime(num)}");
}

Console.WriteLine("\n Дополнительный функционал ");

Console.WriteLine($"2^5 = {Calculator.Power(2, 5)}");
Console.WriteLine($"5! = {Calculator.Factorial(5)}");

if (Calculator.SolveQuadratic(1, -3, 2, out double? root1, out double? root2))
{
    Console.WriteLine($"Корни квадратного уравнения: x1 = {root1}, x2 = {root2}");
}
else
{
    Console.WriteLine("Уравнение не имеет действительных корней.");
}

Console.WriteLine("\nНажмите любую клавишу для выхода...");
Console.ReadKey();