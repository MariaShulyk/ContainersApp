using ContainersApp.Interfaces;

namespace ContainersApp;

public class ColdContainer : BaseСontainer, IHazardNotifier
{
    static private char sortOfContainer = 'C';
    
    public override string SerialNumber { get; set; } = "KON"+$"-{nextId++}-{sortOfContainer}";
    
    public string ProductType { get; set; } 
    
    public int Temerature { get; set; }
    
    public ColdContainer(int height, int containerWeight, int depth, 
        int maxLoadWeight, string productType)
        : base(height, containerWeight, depth, maxLoadWeight)
    {
        if (map.ContainsKey(productType))
        {
            ProductType = productType;
            Temerature = (int)map[productType];
        }
        else
        {   
            sentDangerousNotification("Container can't transport this product");
            throw new ArgumentException("Restricted product type");
        }
    }
    
    private Dictionary<string, double> map = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public override void CargoUnloading()
    {
        throw new NotImplementedException();
    }

    public override void CargoLoading(double cargoWeight)
    {
        throw new NotImplementedException();
    }

    public void sentDangerousNotification(string message)
    {
        throw new NotImplementedException();
    }
}