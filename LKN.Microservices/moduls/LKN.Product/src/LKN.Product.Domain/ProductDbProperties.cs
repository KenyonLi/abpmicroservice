namespace LKN.Product;

public static class ProductDbProperties
{
    public static string DbTablePrefix { get; set; } = "Product";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Product";
    public const string ConnectionMonogDBStringName = "ProductMonogDB";

}
