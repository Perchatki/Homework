using System.Linq.Expressions;

ConsoleKey key;
int selection = 0;

List<int> uneven = new() {1};
List<int> fibonacchiRow = new() {0, 1};

double travelDistance = 10;
double travelDays = 1;

string variants;

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