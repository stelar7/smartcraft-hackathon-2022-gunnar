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
    public class UserTests : BaseTestClass
    {
        public UserTests(AdaptedWebApplicationFactory<backend.Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task CreateUsers_Created20Users_Success()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                IUserRepository repository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var users = await repository.GetRecords();
                Assert.NotEmpty(users);
                Assert.Equal(20, users.Count);
            }
        }
    }
}
