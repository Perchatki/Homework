public abstract class Automobile : Transport
{
    public Engine Engine { get; private set; }

    protected Automobile(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        Engine = engine;
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\n";
    }
    public void Drive(double distance)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака");
        }
    }
}

public sealed class PassangerCar : Automobile
{
    /// <summary> В кубических метрах </summary>
    public double TrunkVolume { get; private set; }
    public PassangerCar(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double trunkVolume, int passangerAmount) : base(name, manufacturer, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        TrunkVolume = trunkVolume;
    }
    public new string GetInfo()
    {
        return base.GetInfo() + $"Объём багажника - {TrunkVolume} метров кубических;";
    }

    public void TrunkFill(double volume)
    {
        if (volume < TrunkVolume)
        {
            Console.WriteLine("Поместилось");
        }
        else
        {
            Console.WriteLine("Не поместилось");
        }
    }
}

public sealed class Lorry : Automobile
{
    /// <summary> В Кг </summary>
    public double CarryWeight { get; private set; }

    public Lorry(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double carryWeight, int passangerAmount) : base(name, manufacturer, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        CarryWeight = carryWeight;
    }
    public new string GetInfo()
    {
        return base.GetInfo() + $"Грузоподъёмность - {CarryWeight}Кг;";
    }

    public void CargoVeightMeasure(double weight)
    {
        if (weight < CarryWeight)
        {
            Console.WriteLine("Хватает грузоподъёмности");
        }
        else
        {
            Console.WriteLine("Не хватает грузоподъёмности");
        }
    }
}