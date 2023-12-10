using System;

public class Process
{
    private static SupplementManagerDB _db; // Assuming SupplementManagerDB is your database class

    public static void Initialize()
    {
        _db = new SupplementManagerDB("supplement_database.db");
        // You might want to add more initialization logic here if needed
    }

    public static void Run()
    {
        Console.WriteLine("Welcome to the Workout Supplement Management System!");

        while (true)
        {
            Console.WriteLine("\n1. View Supplements");
            Console.WriteLine("2. Add Supplement");
            Console.WriteLine("3. Update Supplement");
            Console.WriteLine("4. Delete Supplement");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewSupplements();
                        break;

                    case 2:
                        AddSupplement();
                        break;

                    case 3:
                        UpdateSupplement();
                        break;

                    case 4:
                        DeleteSupplement();
                        break;

                    case 5:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void ViewSupplements()
    {
        // Retrieve and display all supplements
        // You need to implement this method based on your SupplementManagerDB class
        // and how you want to display the supplements
    }

    private static void AddSupplement()
    {
        Console.Write("Enter supplement name: ");
        string name = Console.ReadLine();

        Console.Write("Enter brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            // Create a new supplement and add it to the database
            // You need to implement this method based on your SupplementManagerDB class
            // and how you want to create and add supplements
            Supplement newSupplement = new ProteinPowder(0, name, brand, price);
            _db.InsertSupplement(newSupplement);

            Console.WriteLine("Supplement added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid price. Please enter a valid decimal number.");
        }
    }

    private static void UpdateSupplement()
    {
        // Similar to AddSupplement, but you'll prompt the user for the supplement to update
    }

    private static void DeleteSupplement()
    {
        // Similar to UpdateSupplement, but you'll prompt the user for the supplement to delete
    }
}
