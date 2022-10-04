using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Mongo2Go;
using Moq;
using System;
using System.Security.Cryptography.X509Certificates;
using backend.Repositories;
using backend.Models;
using backend;

namespace Tests
{
    public class AdaptedWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public AdaptedWebApplicationFactory()
        {
            Startup.IsRunningTests = true;
        }



        private MongoDbRunner databaseRunner;
        readonly string databaseName = "TestDB";
        public int MaxPageSize { get; } = 100;
        public int DefaultPageSize { get; } = 50;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            DataBaseSettings settings = InitDatabase();
            builder.ConfigureServices(services =>
            {
                services.Configure<DataBaseSettings>(opts =>
                {
                    opts.DatabaseName = settings.DatabaseName;
                    opts.ConnectionString = settings.ConnectionString;
                });
            });
        }

        private DataBaseSettings InitDatabase()
        {
            databaseRunner = MongoDbRunner.Start();
            DataBaseSettings databaseSettings = new DataBaseSettings
            {
                DatabaseName = databaseName,
                ConnectionString = databaseRunner.ConnectionString
            };
            return databaseSettings;
        }

        public void DropDataBase()
        {
            IMongoDbContext dbContext = GetDataBaseContext();
            dbContext.DropDatabase(databaseName);

        }

        public IMongoDbContext GetDataBaseContext()
        {
            return Services.GetService<IMongoDbContext>();
        }

        protected override void Dispose(bool disposing)
        {
            databaseRunner.Dispose();
            base.Dispose(disposing);
        }
    }
}