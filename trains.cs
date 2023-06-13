public class Train : Transport
{
    public Engine Engine { get; private set; }
    public int TrainCars { get; private set; }

    public Train(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount, int trainCars = 10) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        TrainCars = trainCars;
        Engine = engine;
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\nКоличество вагонов - {TrainCars};";
    }
    public void Route(double distance)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100) Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        else Console.WriteLine("Не хватает объёма бака");
    }
}