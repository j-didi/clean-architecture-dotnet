namespace CleanArchDotnet.Infra.Settings;

public class AppSettings
{
    public string ConnectionString { get; set; }
    public bool IsTestEnvironment { get; set; }
}