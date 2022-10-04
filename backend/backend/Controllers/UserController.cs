using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserRepository repository;
        public UserController(IUserRepository repo)
        {
            repository = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            return await HandleRequest(async () => await repository.GetRecord(Guid.Parse(id)));
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetList()
        {
            return await HandleRequest(async () => await repository.GetRecords());
        }

        [HttpGet("YearlyLeaders")]
        public async Task<ActionResult<List<User>>> GetYearlyLeaders()
        {
            return await HandleRequest(async () => (await repository.GetRecords())
                .OrderByDescending(u => u.ThisYearsScore).ToList());
        }

        [HttpGet("MonthlyLeaders")]
        public async Task<ActionResult<List<User>>> GetMonthlyLeaders()
        {
            return await HandleRequest(async () => (await repository.GetRecords())
                .OrderByDescending(u => u.ThisMonthsScore).ToList());
        }

        [HttpGet("WeeklyLeaders")]
        public async Task<ActionResult<List<User>>> GetWeeklyLeaders()
        {
            return await HandleRequest(async () => (await repository.GetRecords())
                .OrderByDescending(u => u.ThisWeeksScore).ToList());
        }
    }
}
