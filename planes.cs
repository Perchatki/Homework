public abstract class Plane : Transport
{
    public Engine Engine { get; private set; }

    /// <summary> В метрах </summary>
    public double WingSpan { get; private set; }

    protected Plane(string name, string manufacturer, double wingSpan, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        WingSpan = wingSpan;
        Engine = engine;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\nРазмах крыльев - {WingSpan};";
    }

    public virtual void Flight(double distance)
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

public sealed class PassangerPlane : Plane
{
    public bool International { get; private set; }
    public PassangerPlane(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double wingSpan, int passangerAmount, bool international = false) : base(name, manufacturer, wingSpan, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        International = international;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nМежду стран - {(International? "Да" : "Нет")};";
    }

    public void Flight(double distance, int passangersAmount)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100 && passangersAmount <= PassangerAmount)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака или количества мест");
        }
    }

}

public sealed class CargoPlane : Plane
{
    public bool International { get; private set; }

    /// <summary> В Кг </summary>
    public double CarryWeight { get; private set; }
    public CargoPlane(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double carryWeight, double wingSpan, int passangerAmount, bool international = false) : base(name, manufacturer, wingSpan, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        International = international;
        CarryWeight = carryWeight;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"\nМежду стран - {(International ? "Да" : "Нет")};\nГрузоподъёмность - {CarryWeight}Кг";
    }

    public void Flight(double distance, double weight)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance/100 && weight <= CarryWeight)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака или грузоподъёмности");
        }
    }
}
