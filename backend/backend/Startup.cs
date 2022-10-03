using backend.Helpers;
using backend.Models;
using backend.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace backend
{
    public class Startup
    {/// <summary>
     /// ctr
     /// </summary>
     /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// set when running tests to hinder configuration of certain classes for DI
        /// </summary>
        public static bool IsRunningTests { get; set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DataBaseSettings>(Configuration.GetSection("Database"));


            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<CreateDatabase>();

            // Following services are added as mocks by test framework instead 
            if (IsRunningTests == false)
            {
            }

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
