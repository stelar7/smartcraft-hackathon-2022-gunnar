using backend.Helpers;
using backend.Models;
using backend.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xunit;

namespace Tests
{
    public class UserTests : BaseTestClass
    {
        public UserTests(AdaptedWebApplicationFactory<backend.Startup> factory) : base(factory)
        {

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
        public async System.Threading.Tasks.Task GetUser_Gunnar_Success()
        {
            Guid userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            using HttpClient client = CreateClient();
            User user = await Get<User>(client, $"api/User/{userId}");
            Assert.NotNull(user);
            Assert.Equal("Gunnar", user.Name);
        }
    }
}
