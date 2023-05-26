using System;
/*
Console.WriteLine("Привет, \nДаниил");


Console.WriteLine("-1 + 4 * 6 = " + (-1 + 4 * 6));
Console.WriteLine("(35 + 5) % 7 = " + ((35 + 5) % 7));
Console.WriteLine("14 + -4 * 6 / 11 = " + (14 + -4 * 6 / 11));
Console.WriteLine("2 + 15 / 6 * 1 - 7 % 2 = " + (float)(2 + 15 / 6 * 1 - 7 % 2));

Console.WriteLine("Insert 4 numbers");
double a = Convert.ToDouble(Console.ReadLine());
double b = Convert.ToDouble(Console.ReadLine());
double c = Convert.ToDouble(Console.ReadLine());
double d = Convert.ToDouble(Console.ReadLine());
Console.WriteLine((a + b + c + d) / 4);

Console.WriteLine("введите количество страниц");
int m = int.Parse(Console.ReadLine());
Console.WriteLine("введите количество одногруппников");
int n = int.Parse(Console.ReadLine());
if (n >= 0 && m >= 0)
{
    Console.WriteLine(m*n + " pages");
}
else
{
    Console.WriteLine(0 + " pages");
}

1


2
*/
Console.WriteLine("введите 1 число");
double n = float.Parse(Console.ReadLine());
Console.WriteLine("введите 2 число");
double m = float.Parse(Console.ReadLine());
if (n > m)
{
    Console.WriteLine("1 больше");
}
else if (n < m)
{
    Console.WriteLine("1 меньше");
}
else
{
    Console.WriteLine("равны");
}

Console.WriteLine("введите 1 число");
double a = float.Parse(Console.ReadLine());
if (a > 5 && a < 10)
{
    Console.WriteLine("Число больше 5 и меньше 10");
}
else
{
    Console.WriteLine("Неизвестное число");
}


double b = float.Parse(Console.ReadLine());
if (b == 5 && b == 10)
{
    Console.WriteLine("Число либо равно 5, либо равно 10");
}
else
{
    Console.WriteLine("Неизвестное число");
}
