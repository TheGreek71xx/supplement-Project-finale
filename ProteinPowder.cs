// Protein Powder Class
public class ProteinPowder : Supplement
{
    // Constructor
    public ProteinPowder(int supplementId, string name, string brand, decimal price)
    {
        SupplementId = supplementId;
        Name = name;
        Brand = brand;
        Price = price;
    }

    // Implementing abstract method
    public override void DisplaySupplementDetails()
    {
        Console.WriteLine($"Protein Powder: {Name}\nBrand: {Brand}\nPrice: ${Price}");
    }
}

