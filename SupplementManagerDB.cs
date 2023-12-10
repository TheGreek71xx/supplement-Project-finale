using System;
using System.Data.SQLite;

// Supplement Manager Database Class (Composition)
public class SupplementManagerDB : ISupplementInterface
{
    private SQLiteConnection _dbConnection;

    // Constructor
    public SupplementManagerDB(string dbPath)
    {
        _dbConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
        _dbConnection.Open();

        // Create table if not exists
        string createTableQuery = "CREATE TABLE IF NOT EXISTS Supplements (SupplementId INTEGER PRIMARY KEY, Name TEXT, Brand TEXT, Price DECIMAL)";
        SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, _dbConnection);
        createTableCommand.ExecuteNonQuery();
    }

    // Implementing CRUD operations
    public void UpdateSupplementInfo(Supplement supplement, string newBrand, decimal newPrice)
    {
        string updateQuery = "UPDATE Supplements SET Brand = @Brand, Price = @Price WHERE SupplementId = @SupplementId";
        using (SQLiteCommand command = new SQLiteCommand(updateQuery, _dbConnection))
        {
            command.Parameters.AddWithValue("@Brand", newBrand);
            command.Parameters.AddWithValue("@Price", newPrice);
            command.Parameters.AddWithValue("@SupplementId", supplement.SupplementId);
            command.ExecuteNonQuery();
        }
    }

    public void InsertSupplement(Supplement supplement)
    {
        string insertQuery = "INSERT INTO Supplements (Name, Brand, Price) VALUES (@Name, @Brand, @Price)";
        using (SQLiteCommand command = new SQLiteCommand(insertQuery, _dbConnection))
        {
            command.Parameters.AddWithValue("@Name", supplement.Name);
            command.Parameters.AddWithValue("@Brand", supplement.Brand);
            command.Parameters.AddWithValue("@Price", supplement.Price);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteSupplement(int supplementId)
    {
        string deleteQuery = "DELETE FROM Supplements WHERE SupplementId = @SupplementId";
        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, _dbConnection))
        {
            command.Parameters.AddWithValue("@SupplementId", supplementId);
            command.ExecuteNonQuery();
        }
    }

    public Supplement GetSupplementById(int supplementId)
    {
        string selectQuery = "SELECT * FROM Supplements WHERE SupplementId = @SupplementId";
        using (SQLiteCommand command = new SQLiteCommand(selectQuery, _dbConnection))
        {
            command.Parameters.AddWithValue("@SupplementId", supplementId);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string brand = reader["Brand"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);

                    // You need to determine the type of supplement based on your application logic
                    return new ProteinPowder(supplementId, name, brand, price);
                }
            }
        }

        return null;
    }
}
