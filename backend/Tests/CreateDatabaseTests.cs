using backend.Helpers;
using backend.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CreateDatabaseTests : BaseTestClass
    {
        public CreateDatabaseTests(AdaptedWebApplicationFactory<backend.Startup> factory) : base(factory)
        {

        }

        [Fact]
        public void GenerateRandomTaskScore_AllValuesShowUp()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                List<int> list = new List<int>();
                CreateDatabase createDatabase = scope.ServiceProvider.GetRequiredService<CreateDatabase>();
                for(int i = 0; i < 10000; i++)
                {
                    list.Add(createDatabase.GenerateRandomTaskScore());
                }
                Assert.Contains(50, list);
                Assert.Contains(60, list);
                Assert.Contains(70, list);
                Assert.Contains(80, list);
                Assert.Contains(90, list);
                Assert.Contains(100, list);
                Assert.Contains(110, list);
                Assert.Contains(120, list);
                Assert.Contains(130, list);
                Assert.Contains(140, list);
                Assert.Contains(150, list);
                Assert.Contains(160, list);
                Assert.Contains(170, list);
                Assert.Contains(180, list);
                Assert.Contains(190, list);
                Assert.Contains(200, list);
                Assert.DoesNotContain(210, list);
                Assert.DoesNotContain(40, list);

            }           
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateUsers_Created20Users_Success()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                IUserRepository repository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var users = await repository.GetRecords();
                Assert.NotEmpty(users);
                Assert.Equal(21, users.Count);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateTasks_Created20Users_Success()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                ITaskRepository repository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                var tasks = await repository.GetRecords();
                Assert.NotEmpty(tasks);
                Assert.Equal(10, tasks.Count);
            }
        }
    }
}
