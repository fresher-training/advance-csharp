using advance_csharp.database.Models;

namespace advance_csharp_dummy
{
    public static class ProductExtension
    {
        public static long SummaryTotalPrice(this Product product)
        {
            return product.Quantity * Int32.Parse(product.Price);
        }
    }
}
