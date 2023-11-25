using advance_csharp.database.Models;

namespace advance_csharp_dummy
{
    /// <summary>
    /// Documentation
    /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    /// </summary>
    public static class ProductExtension
    {
        public static long SummaryTotalPrice(this Product product)
        {
            return product.Quantity * Int32.Parse(product.Price);
        }
    }
}
