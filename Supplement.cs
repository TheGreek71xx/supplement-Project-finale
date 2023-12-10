// Supplement Abstract Class
public abstract class Supplement
{
    public int SupplementId { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }

    public abstract void DisplaySupplementDetails();
}
