# MathLibrary - Библиотека математических функций

## Описание
MathLibrary представляет собой библиотеку классов на C#, предоставляющую набор математических функций для использования в .NET приложениях. Библиотека разработана в рамках практической работы по модульному программированию.

## Возможности библиотеки

### Базовые арифметические операции
- **Add(double a, double b)** - сложение двух чисел
- **Subtract(double a, double b)** - вычитание чисел
- **Multiply(double a, double b)** - умножение чисел
- **Divide(double a, double b)** - деление чисел (с обработкой деления на ноль)

### Математические функции
- **Power(double number, double power)** - возведение числа в степень
- **Factorial(int n)** - вычисление факториала числа (n!)
- **IsPrime(int number)** - проверка числа на простоту
- **SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)** - решение квадратного уравнения

## Примеры использования

```csharp
using MathLibrary;

// Пример 1: Базовые операции
double sum = Calculator.Add(15, 7);        // 22
double difference = Calculator.Subtract(15, 7);  // 8
double product = Calculator.Multiply(15, 7);      // 105
double quotient = Calculator.Divide(15, 7);       // 2.142857...

// Пример 2: Возведение в степень
double result = Calculator.Power(2, 10);    // 1024

// Пример 3: Факториал
int fact = Calculator.Factorial(5);         // 120

// Пример 4: Проверка на простое число
bool isPrime = Calculator.IsPrime(17);      // true

// Пример 5: Решение квадратного уравнения
bool hasRoots = Calculator.SolveQuadratic(1, -5, 6, out var x1, out var x2);
// Результат: x1 = 3, x2 = 2

// Пример 6: Обработка ошибок
try
{
    Calculator.Divide(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}