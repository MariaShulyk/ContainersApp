using ContainersApp.Interfaces;

namespace ContainersApp;

public class LiquidContainer(int height, int containerWeight, int depth, 
    int maxLoadWeight, bool isDangerous ) : BaseСontainer(height, containerWeight, depth, maxLoadWeight), IHazardNotifier
{
    static private char sortOfContainer = 'L';
    
    public override string SerialNumber { get; set; } = "KON"+$"-{nextId++}-{sortOfContainer}";
    
    public bool IsDangerous { get; set; } = isDangerous;

    public override void CargoUnloading()
    {
        CargoWeight = 0;
    }

    public override void CargoLoading(double cargoWeight)
    {
        if (IsDangerous)
        {
            if (cargoWeight > MaxLoadWeight * 0.5)
            {
                sentDangerousNotification("Loading weight of container number "+$"{SerialNumber}" + " is too high");
            }
        }
        else
        {
            if (cargoWeight > MaxLoadWeight * 0.9)
            {
                sentDangerousNotification("Loading weight is too high");
            } 
        }
        
        if (cargoWeight > MaxLoadWeight)
        {
            throw new OverfillException("Loading weight is too high");
        }
        
        CargoWeight = cargoWeight;
    }

    public void sentDangerousNotification(string msg)
    {
        Console.WriteLine($"Dangerous situation with container({SerialNumber}) : {msg}" );
    }

    public override string ToString()
    {
        return $"SerialNumber: {SerialNumber}, {base.ToString()}, IsDangerousCargo: {IsDangerous}";;
    }
}