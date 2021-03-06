public class Program
{
    public static void Main(string[] args)
    {
        var logger = NLogBuilder.ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();
        try
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        catch(Exception ex)
        {
            logger.Error(ex, "API stopped because of this exception");
            throw;
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)            
            .UseStartup<Startup>()
            .UseNLog();
}