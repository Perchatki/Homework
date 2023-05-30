using System.Linq.Expressions;

ConsoleKey key;
int selection = 0;

List<int> uneven = new() {1};
List<int> fibonacchiRow = new() {0, 1};

double travelDistance = 10;
double travelDays = 1;

string variants;
//i = func(i); рекурсивная функция
//var func(var input) return /equasion with input/ ;
while (true)
{
    Console.Clear();
    Console.WriteLine("Выберите стрелочками номер задания:");
    Console.WriteLine(variants = "1 2 3");

    Console.CursorTop = 1;
    Console.CursorLeft = selection;

    while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
    {
        if (key == ConsoleKey.LeftArrow)
        {
            if (Console.CursorLeft == 0)
            {
                Console.CursorLeft = variants.Length - 1;
            }

            Console.CursorLeft -= 2;
        }
        else if (key == ConsoleKey.RightArrow)
        {
            Console.CursorLeft += 2;

            if (Console.CursorLeft > variants.Length - 1)
            {
                Console.CursorLeft = 0;
            }
        }
    }
    selection = Console.CursorLeft;
    Highlight(selection);

    Console.Write("\nНажмите любую клавишу, чтобы продолжить, или Escape, чтобы отменить выбор");
    Console.CursorTop = 1;
    Console.CursorLeft = selection;

    if (Console.ReadKey(true).Key == ConsoleKey.Escape) continue;

    Console.Clear();

    switch (selection)
    {
        case 0:
            while (fibonacchiRow.Count < 10)
            {
                fibonacchiRow.Add(FibonacchiNextDigit(fibonacchiRow));
            }
            Console.WriteLine("Первые 10 чисел Фибоначчи:");
            WriteWithColor(IntListToString(fibonacchiRow),ConsoleColor.Red);
            break;
        case 2:
            while (uneven[uneven.Count-1] < 99)
            {
                uneven.Add(uneven[uneven.Count - 1] + 2);
            }

            Console.WriteLine("Нечётные числа от 0 до 100:");
            WriteWithColor(IntListToString(uneven), ConsoleColor.Red);
            break;
        case 4:
            while (travelDistance < 100)
            {
                travelDistance += travelDistance * 0.1;
                travelDays++;
            }
            Console.Write("Начав тренировки, лыжник в первый день пробежал 10 км. \nКаждый следующий день он увеличивал пробег на 10% от \nпробега предыдущего дня. На ");
            WriteWithColor(travelDays.ToString(), ConsoleColor.Red);
            Console.Write(" день он преодолел \nрубеж в 100км с результатом ");
            WriteWithColor(Math.Round(travelDistance, 2).ToString(), ConsoleColor.Red);
            Console.Write("км");
            break;
        default:
            break;
    }
    Console.ReadKey(true);
}

void Highlight(int highlightIndex)
{
    Console.CursorLeft = 0;
    for (int i = 0; i < highlightIndex; i++)
    {
        Console.Write(variants[i]);
    }

    WriteWithColor(variants[highlightIndex].ToString(), ConsoleColor.Red);

    for (int i = highlightIndex + 1; i < variants.Length - 1; i++)
    {
        Console.Write(variants[i]);
    }
}

int FibonacchiNextDigit(List<int> input)
{
    return (input[input.Count - 2] + input[input.Count - 1]);
}


string IntListToString(List<int> input)
{
    string output = "";
    int transferCounter = 10;
    foreach (int i in input)
    {
        output += i + (i / 10 < 1 ? "  " : " ");

        transferCounter--;
        if (transferCounter <= 0)
        {
            transferCounter = 10;
            output += "\n";
        }
    }

    return output;
}

void WriteWithColor(string input, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(input);
    Console.ResetColor();
}


/* Console.Clear();
Console.WriteLine("Введите номер задания:");
switch (Console.ReadLine())
{
    case "1":
    start1:


        left = Console.CursorLeft;
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Введите число");
        if (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start1;
        }

        Console.WriteLine("Результат: " + ((top == 1) ? ((value * 9 / 5) + 32) : (value + 273.15)));
        break;
    case "2":
    start2:
        Console.Clear();
        Console.WriteLine("Выберите стрелочками операцию:");
        Console.WriteLine("+");
        Console.WriteLine("-");
        Console.WriteLine("*");
        Console.WriteLine("/");
        Console.WriteLine("%");
        Console.CursorTop = 1;

        while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
        {
            if (key == ConsoleKey.UpArrow)
            {
                Console.CursorTop--;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                Console.CursorTop++;
            }

            if (Console.CursorTop < 1)
            {
                Console.CursorTop = 1;
            }
            else if (Console.CursorTop > 5)
            {
                Console.CursorTop = 5;
            }
        }

        top = Console.CursorTop;
        Console.ForegroundColor = ConsoleColor.Red;
        switch (top)
        {
            case 1:
                Console.WriteLine("+");
                break;
            case 2:
                Console.WriteLine("-");
                break;
            case 3:
                Console.WriteLine("*");
                break;
            case 4:
                Console.WriteLine("/");
                break;
            case 5:
                Console.WriteLine("%");
                break;
            default:
                break;
        }
        Console.WriteLine();
        Console.ResetColor();
        Console.CursorTop = 6;

        Console.WriteLine("Введите 1 число");
        if (!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start2;
        }

        Console.WriteLine("Введите 2 число");
        if (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start2;
        }

        switch (top)
        {
            case 1:
                Console.WriteLine("Результат: " + (a + b));
                break;
            case 2:
                Console.WriteLine("Результат: " + (a - b));
                break;
            case 3:
                Console.WriteLine("Результат: " + (a * b));
                break;
            case 4:
                Console.WriteLine("Результат: " + (a / b));
                break;
            case 5:
                Console.WriteLine("Результат: " + (a % b));
                break;
            default:
                break;
        }
        break;
    case "3":
    start3:
        Console.Clear();
        Console.WriteLine("Введите 1 число");

        if (!int.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start3;
        }
        if (x is > 9 or < 0)
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start3;
        }

        Console.WriteLine("Введите 2 число");
        if (!int.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start3;
        }
        if (y is > 9 or < 0)
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start3;
        }


        Console.WriteLine("Введите результат перемножения чисел");
        if (!int.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start3;
        }
        if (output == x * y)
        {
            Console.WriteLine("Верно!");
            break;
        }
        Console.WriteLine("Неверно! Правильный ответ: " + (x * y));
        break;
    case "4":
    start4:
        Console.Clear();
        Console.WriteLine("Введите число");
        if (!int.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start4;
        }
        else if (output is < 1 or > 99)
        {
            Console.WriteLine("Ошибка");
            _ = Console.ReadKey();
            goto start4;
        }

        if (output % 10 == 1 && output != 11)
        {
            Console.WriteLine(output + " год");
        }
        else if ((output % 10 == 2 && output != 12) || (output % 10 == 3 && output != 13) || (output % 10 == 4 && output != 14))
        {
            Console.WriteLine(output + " года");
        }
        else
        {
            Console.WriteLine(output + " лет");
        }

        break;
    default:
        Console.WriteLine("Ошибка");
        break;
}
Console.ReadKey();
} */