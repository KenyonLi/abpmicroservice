namespace LKN.AuthMicroService;

public static class AuthMicroServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "AuthMicroService";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AuthMicroService";
}
