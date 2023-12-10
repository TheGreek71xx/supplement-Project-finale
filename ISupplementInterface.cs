// Supplement Interface
public interface ISupplementInterface
{
    void UpdateSupplementInfo(Supplement supplement, string newBrand, decimal newPrice);
    void InsertSupplement(Supplement supplement);
    void DeleteSupplement(int supplementId);
    Supplement GetSupplementById(int supplementId);
}
