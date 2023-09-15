namespace LKN.User;

public static class UserDbProperties
{
    public static string DbTablePrefix { get; set; } = "User";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "User";
}
