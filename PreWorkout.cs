// Pre-Workout Class
public class PreWorkout : Supplement
{
    // Constructor
    public PreWorkout(int supplementId, string name, string brand, decimal price)
    {
        SupplementId = supplementId;
        Name = name;
        Brand = brand;
        Price = price;
    }

    // Implementing abstract method
    public override void DisplaySupplementDetails()
    {
        Console.WriteLine($"Pre-Workout: {Name}\nBrand: {Brand}\nPrice: ${Price}");
    }
}
