using Dotnetwindowsservice;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog().UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        var progdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console().WriteTo.File(Path.Combine(progdata, "coursedemos","servicelog.txt")).CreateLogger();

       
    })
    .Build();

await host.RunAsync();
