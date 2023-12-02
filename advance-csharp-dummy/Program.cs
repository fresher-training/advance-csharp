// See https://aka.ms/new-console-template for more information
using advance_csharp.database;
using advance_csharp.database.Models;
using advance_csharp_dummy;

Console.WriteLine("Insert products!");
Random rnd = new();
Random rndQuantity = new();
Random rndCategory = new();
string[] categoryList = new string[] { "Cloth", "Electric", "Tech", "Food", "Drink" };
for (int i = 0; i < 100; i++)
{
    try
    {
        using AdvanceCsharpContext context = new();
        int priceNum = rnd.Next(100000, 10000000);
        int quantity = rndQuantity.Next(1, 1000);
        int categoryNum = rndCategory.Next(1, 5);
        List<string> category = new();
        for (int j = 0; j < categoryNum - 1; j++)
        {
            category.Add(categoryList[j]);
        }
        Product product = new()
        {
            Name = "Product " + i.ToString(),
            Price = priceNum.ToString(),
            Quantity = quantity,
            Images = "",
            Category = string.Join(",", category)
        };
        Console.WriteLine("Total Price: " + product.SummaryTotalPrice());
        Console.WriteLine("Inserted product! " + product.Id);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
Console.WriteLine("Finish");
Console.ReadLine();