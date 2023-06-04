using System.Linq.Expressions;

Random  random = new();

ConsoleKey key;
int selection = 0;


string variants = "1 2";

bool isSecondTask = false;


int rng = random.Next(2, 5);
int[] array = new int[rng];
for (int i = 0; i < rng; i++)
{
    rng = random.Next(-5, 5);
    array[i] = rng;
}

int[,] journal = new int[3, 5];
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 5; j++)
    {
        rng = random.Next(2, 6);
        journal[i, j] = rng;
    }
}

while (true)
{
    Highlight(selection = Select("1 2", "Номер задания",1,0,2,0,2).Item1, (selection/2+1).ToString());

    Console.Write("\nНажмите любую клавишу, чтобы продолжить, или Escape, чтобы отменить выбор");
    Console.CursorTop = 1;
    Console.CursorLeft = selection;

    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
    {
        isSecondTask = false;
        variants = "1 2";
        continue;
    }

    Console.Clear();

    if (!isSecondTask)
    {
        switch (selection)
        {
            case 0:
                string table = "Уч Ин Ри Оо";
                for (int i = 0;i < 5; i++)
                {
                    table += $"\n№{i+1} ";
                    for (int j = 0; j < 3; j++)
                    {
                        table += journal[j, i] + "  ";
                    }
                }
                (int,int) itemSelection = Select(table, "номер предмета", 2, 3, 9, 6, 3);

                Highlight(itemSelection.Item1, "-");


                int newValue;

                retry:
                Console.CursorTop = 0;
                Console.CursorLeft = 0;
                Console.Write("Введите новое значение:             ");
                Console.CursorLeft = 23;
                if (!int.TryParse(Console.ReadLine(), out newValue) || newValue is > 5 or < 2)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                    Console.Write("Ошибка. Введите новое значение:");
                    goto retry;
                }

                journal[(itemSelection.Item1 - 3)/3, itemSelection.Item2 - 2] = newValue;
                Console.CursorTop = 0;
                Console.CursorLeft = 23;

                Console.ReadKey(true);

                Console.Clear();

                table = "Уч Ин Ри Оо";
                for (int i = 0; i < 5; i++)
                {
                    table += $"\n№{i + 1} ";
                    for (int j = 0; j < 3; j++)
                    {
                        table += journal[j, i] + "  ";
                    }
                }
                Console.WriteLine(table);
                Console.ReadKey(true);
                break;

            case 2:
                variants = "1 2 3 4";
                isSecondTask = true;

                break;
            default:
                break;
        }
        Console.ReadKey(true);
    }

    switch (selection)
    {
        case 0:
            WriteWithColor(IntArrayToString(array.GetLength(0), array), ConsoleColor.Red);
            break;
        case 2:
            int[] buffer = array;
            for (int i = 0; i < array.Length; i++)
            {
                array[array.Length - i - 1] = buffer[i];
            }
            WriteWithColor(IntArrayToString(array.GetLength(0), array),ConsoleColor.Red);
            break;
        case 4:

            break;
        case 6:

            break;
        default:
            break;
    }

    variants = "1 2";
    isSecondTask = false;

    Console.ReadKey(true);
}

void Highlight(int highlightIndex, string text)
{
    Console.CursorLeft = highlightIndex;
    WriteWithColor(text, ConsoleColor.Red);
}


string IntArrayToString(int transferCounter,int[] input = null)
{
    string output = "";
    int max = transferCounter;
    foreach (int i in input)
    {
        output += i + (i / 10 < 1 ? "  " : " ");

        transferCounter--;
        if (transferCounter <= 0)
        {
            transferCounter = max;
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

(int,int) Select(string variants, string subject, int cursorTop = 1, int cursorLeft = 0, int boundsHorizontal = 0, int boundsVertical = 0, int jump = 2)
{
    Console.Clear();
    Console.WriteLine($"Выберите стрелочками {subject}:");
    Console.WriteLine(variants);

    Console.CursorTop = cursorTop;
    Console.CursorLeft = cursorLeft;

    while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
    {
            if (key == ConsoleKey.LeftArrow)
            {
                if (Console.CursorLeft == cursorLeft)
                {
                    Console.CursorLeft = boundsHorizontal + cursorLeft;
                }
                else Console.CursorLeft -= jump;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                Console.CursorLeft += jump;

                if (Console.CursorLeft > boundsHorizontal)
                {
                    Console.CursorLeft = cursorLeft;
                }
            }
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (Console.CursorTop == cursorTop)
                {
                    Console.CursorTop = boundsVertical + cursorTop;
                }
                else Console.CursorTop--;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                Console.CursorTop++;

                if (Console.CursorTop > boundsVertical)
                {
                    Console.CursorTop = cursorTop;
                }
            }
        }
    }
    return (Console.CursorLeft, Console.CursorTop);
}