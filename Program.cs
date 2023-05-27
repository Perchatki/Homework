ConsoleKey key;
double a,b,value;
int top, output;
string alpha, beta;

while (true)
{
    Console.Clear();
    Console.WriteLine("Введите номер задания:");
    switch (Console.ReadLine())
    {
        case "1":
        start1:
            Console.Clear();
            Console.WriteLine("Выберите стрелочками единицу измерения:");
            Console.WriteLine("Фаренгейт");
            Console.WriteLine("Кельвин");
            Console.CursorTop = 1;

            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.UpArrow)
                {
                    Console.CursorTop = 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    Console.CursorTop = 2;
                }
            }

            top = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine((top == 1) ? "Фаренгейт" : "Кельвин");
            Console.ResetColor();
            Console.CursorTop = 3;

            Console.WriteLine("Введите число");
            if (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
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
                Console.ReadKey();
                goto start2;
            }

            Console.WriteLine("Введите 2 число");
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
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
            alpha = Console.ReadLine();
            if (alpha != "1" && alpha != "2" && alpha != "3" && alpha != "4" && alpha != "5" && alpha != "6" && alpha != "7" && alpha != "8" && alpha != "9" && alpha != "0")
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                goto start3;
            }

            Console.WriteLine("Введите 2 число");
            beta = Console.ReadLine();
            if (beta != "1" && beta != "2" && beta != "3" && beta != "4" && beta != "5" && beta != "6" && beta != "7" && beta != "8" && beta != "9" && beta != "0")
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                goto start3;
            }


            Console.WriteLine("Введите результат перемножения чисел");
            if (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                goto start3;
            }
            if (output == int.Parse(alpha) * int.Parse(beta))
            {
                Console.WriteLine("Верно!");
                break;
            }
            Console.WriteLine("Неверно! Правильный ответ: " + int.Parse(alpha) * int.Parse(beta));
            break;
        case "4":
        start4:
            Console.Clear();
            Console.WriteLine("Введите число");
            if (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                goto start4;
            }
            else if (output < 1 || output > 99)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                goto start4;
            }

            if (output % 10 == 1 && output != 11) 
                Console.WriteLine(output + " год");
            else if (output % 10 == 2 && output != 12 || output % 10 == 3 && output != 13 || output % 10 == 4 && output != 14) 
                Console.WriteLine(output + " года");
            else 
                Console.WriteLine(output + " лет");
            break;
        default:
            Console.WriteLine("Ошибка");
            break;
    }
    Console.ReadKey();
}