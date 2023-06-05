namespace NewsAPI.Infrastructure.Persistence;

public static class ConnectionString
{
    private static string DatabaseServer = "";

    private static string DatabasePort = "";

    private static string DatabaseName = "";

    private static string DatabaseUser = "";

    private static string DatabasePassword = "";

    public static string BuildConnection()
    {
        return
            $"Server={DatabaseServer},{DatabasePort};Database={DatabaseName};User Id={DatabaseUser};Password={DatabasePassword};TrustServerCertificate=true";
    }
}

