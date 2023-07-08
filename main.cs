int account = 0;

List<Good> goods = new()
{
    new(10, 100, "Чипсончики"),
    new(10, 100, "Энергосик"),
    new(10, 100, "Сухарёчки"),
    new(10, 100, "Кола"),
    new(10, 100, "КитКат"),
    new(10, 100, "Твикс"),
    new(10, 100, "Сникерс"),
    new(10, 100, "Пряник"),
    new(10, 100, "Шоколадка"),
    new(10, 100, "Фанта")
};




while (true)
{
    if (account > 0)
    {
        Console.WriteLine("На счету " + account + " Рублей");
    }

    Console.WriteLine("Введите Команду: AddMoney, GetChange, ShowGoods, BuyGood {id} {count}");
repeatCommand:
    string[] command = Console.ReadLine().Split(" ");
    switch (command[0])
    {
        case "AddMoney":
            if (command.Length < 2)
            {
                AddMoney();
                break;
            }
            Console.Clear();
            Console.WriteLine("Неверная команда, повторите ввод");
            goto repeatCommand;
        case "GetChange":
            if (command.Length < 2)
            {
                GetChange();
                break;
            }
            Console.Clear();
            Console.WriteLine("Неверная команда, повторите ввод");
            goto repeatCommand;
        case "ShowGoods":
            if (command.Length < 2)
            {
                ShowGoods();
                break;
            }
            Console.Clear();
            Console.WriteLine("Неверная команда, повторите ввод");
            goto repeatCommand;
        case "BuyGood":
            if (command.Length == 3 && int.TryParse(command[1], out int _) && int.TryParse(command[2], out int _))
            {
                BuyGood(command);
                break;
            }
            Console.Clear();
            Console.WriteLine("Неверная команда, повторите ввод");
            goto repeatCommand;
        default:
            Console.Clear();
            Console.WriteLine("Неверная команда, повторите ввод");
            goto repeatCommand;
    }
}

void AddMoney()
{
    Console.WriteLine("Введите тип оплаты: Монеты или Карта");
paymentSelect:
    string paymentMethod = Console.ReadLine();
    switch (paymentMethod)
    {
        case "Монеты":
            AddToAccount(true);
            break;
        case "Карта":
            AddToAccount(false);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Неверный тип оплаты, повторите ввод: Монеты или Карта");
            goto paymentSelect;
    }
}

int CountCoins(string coins, bool isCoins)
{
    int result = 0;
    int i = 0;
    int[] multipliers = new int[] { 1, 2, 5, 10 };
    if (isCoins)
    {
        foreach (string coin in coins.Split(' '))
        {
            if (i > 3 || !int.TryParse(coin, out int add))
            {
                return -1;
            }

            result += add * multipliers[i];
            i++;
        }
    }
    else if (!int.TryParse(coins, out result))
    {
        return -1;
    }

    return result;
}

void AddToAccount(bool isCoins)
{
    Console.WriteLine($"Выбранный тип оплаты: {(isCoins ? "Монеты" : "Карта")}" +
                $"\nВведите количество {(isCoins ? "монет по 1, 2, 5 и 10 рублей через пробел" : "рублей")} ");
countCoins:
    string coins = Console.ReadLine();
    int addCoins = CountCoins(coins, isCoins);
    if (addCoins < 0)
    {
        Console.WriteLine($"Ошибка ввода, повторите ввод {(isCoins ? "монет по 1, 2, 5 и 10 рублей через пробел" : "суммы денег")}");
        goto countCoins;
    }
    else
    {
        account += addCoins;
        Console.WriteLine($"Введено {addCoins} рублей");
        _ = Console.ReadKey(true);
        Console.Clear();
    }
}

void GetChange() //1, 2, 5, 10
{
    int accountBuffer = account;
    int[] result = { 0, 0, 0, 0 };
    int i;
    int[] multipliers = new int[] { 10, 5, 2, 1 };
    for (i = 0; i < multipliers.Length; i++)
    {
        result[i] = accountBuffer / multipliers[i];
        accountBuffer -= result[i] * multipliers[i];
    }
    account = 0;
    Console.WriteLine($"Получено монет номиналом 10 - {result[0]}, 5 - {result[1]}, 2 - {result[2]}, 1 - {result[3]}");
    _ = Console.ReadKey(true);
    Console.Clear();
}

void ShowGoods()
{
    foreach (Good good in goods)
    {
        Console.WriteLine($"Название - {good.Name}; Цена - {good.Price}; Количество - {good.Count}");
    }
    _ = Console.ReadKey(true);
    Console.Clear();
}

void BuyGood(string[] command)
{
    if (int.TryParse(command[1], out int id) && int.TryParse(command[2], out int count))
    {
        int price = -1;

        if (id < goods.Count && id >= 0)
        {
            price = goods[id].Buy(count, account);
        }

        if (price < 0 || id >= goods.Count)
        {
            Console.WriteLine("Ошибка количества товара или средств");
            _ = Console.ReadKey(true);
            Console.Clear();
            return;
        }
        Console.WriteLine($"Куплено - {goods[id].Name} В количестве - {count} По цене - {count * goods[id].Price}");
        account -= price;
        _ = Console.ReadKey(true);
        Console.Clear();
    }
}

internal class Good
{
    public int Count { get; private set; }
    public int Price { get; private set; }
    public string Name { get; private set; }

    public Good(int count, int price, string name)
    {
        Count = count;
        Price = price;
        Name = name;
    }

    public int Buy(int count, int account)
    {
        if (count * Price > account || count > Count || count <= 0)
        {
            return -1;
        }
        else
        {
            Count -= count;
            return count * Price;
        }
    }
}