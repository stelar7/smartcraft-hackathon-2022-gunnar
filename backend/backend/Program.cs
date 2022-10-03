using backend;
using backend.Helpers;
using backend.Repositories;

IHost host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    CreateDatabase createDatabase = scope.ServiceProvider.GetRequiredService<CreateDatabase>();
    IMongoDbContext dbContext = scope.ServiceProvider.GetRequiredService<IMongoDbContext>();
    createDatabase.InitializeDatabase().Wait();
}
host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });