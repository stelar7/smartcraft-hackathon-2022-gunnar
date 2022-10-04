using backend.Helpers;
using backend.Models;
using backend.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async System.Threading.Tasks.Task GetUser_Gunnar_Success()
        {
            Guid userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            using HttpClient client = CreateClient();
            User user = await Get<User>(client, $"api/User/{userId}");
            Assert.NotNull(user);
            Assert.Equal("Gunnar", user.Name);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetWeeklyLeaders()
        {
            using HttpClient client = CreateClient();
            List<User> users = await Get<List<User>>(client, $"api/User/WeeklyLeaders");

            Assert.NotEmpty(users);
            Assert.True(users.First().ThisWeeksScore > users.Last().ThisWeeksScore);
            Assert.True(users[0].ThisWeeksScore >= users[1].ThisWeeksScore);
            Assert.True(users[1].ThisWeeksScore >= users[2].ThisWeeksScore);
            Assert.True(users[2].ThisWeeksScore >= users[3].ThisWeeksScore);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetMonthlyLeaders()
        {
            using HttpClient client = CreateClient();
            List<User> users = await Get<List<User>>(client, $"api/User/MonthlyLeaders");

            Assert.NotEmpty(users);
            Assert.True(users.First().ThisMonthsScore > users.Last().ThisMonthsScore);
            Assert.True(users[0].ThisMonthsScore >= users[1].ThisMonthsScore);
            Assert.True(users[1].ThisMonthsScore >= users[2].ThisMonthsScore);
            Assert.True(users[2].ThisMonthsScore >= users[3].ThisMonthsScore);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetYearlyLeaders()
        {
            using HttpClient client = CreateClient();
            List<User> users = await Get<List<User>>(client, $"api/User/YearlyLeaders");

            Assert.NotEmpty(users);
            Assert.True(users.First().ThisYearsScore > users.Last().ThisYearsScore);
            Assert.True(users[0].ThisYearsScore >= users[1].ThisYearsScore);
            Assert.True(users[1].ThisYearsScore >= users[2].ThisYearsScore);
            Assert.True(users[2].ThisYearsScore >= users[3].ThisYearsScore);
        }
    }
}
