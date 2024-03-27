namespace ContainersApp;

public class Ship(double maxTotalWeightOfCargoInContainers, int maxSpeed, int maxContainerCount)
{
    public List<BaseСontainer> Containers { get; set; } = new List<BaseСontainer>();
    public double MaxSpeed { get; set; } = maxSpeed;
    public int MaxContainerCount { get; set; } = maxContainerCount;
    public double MaxTotalWeightOfCargoInContainers { get; set; } = maxTotalWeightOfCargoInContainers;
    
    public void AddContainer(BaseСontainer container)
    {
        if (Containers.Count >= MaxContainerCount || GetTotalWeight() > MaxTotalWeightOfCargoInContainers)
        {
            throw new OverfillException("Container can't be added. Max total weight is too high");
        }
        Containers.Add(container);
    }
    
    
    
    public void TransferContainerToAnOtherShip(Ship anotherShip, string serialNumber)
    {
        var containerToTransfer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToTransfer != null)
        {
            DeleteContainer(serialNumber);
            anotherShip.AddContainer(containerToTransfer);
        }
        else
        {
            throw new ArgumentException("Failed transfering container");
        }
    }

    public void DeleteContainer(string serialNumber)
    {
        var containerToDelete = Containers.FirstOrDefault(container => container.SerialNumber == serialNumber);
        if (containerToDelete != null)
        {
            Containers.Remove(containerToDelete);
        }
        else
        {
            throw new ArgumentException("Container not found");
        }
    }

    public double GetTotalWeight()
    {
        return Containers.Sum(contain => contain.ContainerWeight + contain.CargoWeight);
    }
    public void AddContainers(List<BaseСontainer> containersToLoad)
    {
        foreach (var container in containersToLoad)
        {
            try
            {
                AddContainer(container);
            }
            catch (OverfillException e)
            {
                Console.WriteLine("Failed loading container");
            }
        }
    }
    
    public override string ToString()
    {
        return $"[{GetType().Name}] -- MaxSpeed:{MaxSpeed}, MaxContainerCount: {MaxContainerCount}, MaxTotalWeightOfCargoInContainers: {MaxTotalWeightOfCargoInContainers},  Number of containers in the ship: {Containers.Count}";
    }
}