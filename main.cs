Engine v6 = new("Volvo", "V6 PRV engine", 97, 300);

PassangerCar car = new("DeLorean", "DMC", v6, 800, 800, 100, 3000000, 1, 2);
Console.WriteLine(car.GetInfo());
Console.WriteLine();

Lorry lorry = new("LIAZ 123", "LIAZ", v6, 800, 800, 100, 3000000, 100000, 2);
Console.WriteLine(lorry.GetInfo());
Console.WriteLine();

CargoPlane cargoPlane = new("Boeing 123", "Boeing", v6, 8000, 80000, 500, 300000000, 1000000, 10, 0);
cargoPlane.Flight(100, 10000);
Console.WriteLine();
Console.WriteLine(cargoPlane.GetInfo());
Console.WriteLine();

PassangerPlane passangerPlane = new("Boeing 767", "Boeing", v6, 700, 80000, 100, 300000000, 10, 100, true);
Console.WriteLine(passangerPlane.GetInfo());
Console.WriteLine();

Train train = new("Ласточка", "РЖД", v6, 8000000, 800000, 70, 800000000, 800, 10);
Console.WriteLine(train.GetInfo());
Console.WriteLine();

public abstract class Transport
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }

    /// <summary> Количество энергии в баке/батарее в КВт*Ч </summary>
    public double EnergyStorage { get; private set; }
    public double Weight { get; private set; }
    public double Speed { get; private set; }
    public double Price { get; private set; }
    public int PassangerAmount { get; private set; }

    public Transport(string name, string manufacturer, double energyStorage, double weight, double speed, double price, int passangerAmount = 4)
    {
        Name = name;
        Manufacturer = manufacturer;
        PassangerAmount = passangerAmount;
        EnergyStorage = energyStorage;
        Weight = weight;
        Speed = speed;
        Price = price;
    }

    public virtual string GetInfo()
    {
        return $"Название - {Name};\nПроизводитель - {Manufacturer};\nКоличество пассажиров - {PassangerAmount};\nВместимось энергии - {EnergyStorage}КВт*ч;\nВес - {Weight}Кг;\nСкорость - {Speed}Км/Ч;\nЦена - {Price} Рублей;";
    }
}
public class Engine
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }

    /// <summary> Мощность в КВт </summary>
    public double Power { get; private set; }

    /// <summary> Энергопотребление в КВт*Ч/100Км </summary>
    public double EnergyConsumption { get; private set; }

    public Engine(string manufacturer, string name, double power, double energyConsumption)
    {
        Manufacturer = manufacturer;
        Name = name;
        Power = power;
        EnergyConsumption = energyConsumption;
    }

    public override string ToString()
    {
        return $"Название - {Name};\nМощность - {Power}КВт;\nЭнергопотребление - {EnergyConsumption}КВт*Ч/100Км";
    }
}


