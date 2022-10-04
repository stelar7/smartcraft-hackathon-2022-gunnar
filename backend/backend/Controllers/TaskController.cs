using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController
    {
        private readonly ITaskRepository repository;
        public TaskController(ITaskRepository repo)
        {
            repository = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> Get(string id)
        {
            return await HandleRequest(async () => await repository.GetRecord(Guid.Parse(id)));
        }

        [HttpGet("owner/{ownerid}")]
        public async Task<ActionResult<List<Models.Task>>> GetOwnersTasks(string ownerid)
        {
            return await HandleRequest(async () => await repository.GetRecordsOwnedBy(Guid.Parse(ownerid)));
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetAvailableTasks()
        {
            return await HandleRequest(async () => await repository.GetAvailableTasks());
        }

        [HttpPut("Reserve/{id}")]
        public async Task<ActionResult<Models.Task>> ReserveTask(string id, string userId)
        {
            return await HandleRequest(async () => await repository.ReserveTask(Guid.Parse(id), Guid.Parse(userId)));
        }

        [HttpPut("Complete/{id}")]
        public async Task<ActionResult<Models.Task>> CompleteTask(string id)
        {
            return await HandleRequest(async () => await repository.CompleteTask(Guid.Parse(id)));
        }

        [HttpPut("Pick/{id}")]
        public async Task<ActionResult<Models.Task>> PickTask(string id)
        {
            return await HandleRequest(async () => await repository.PickTask(Guid.Parse(id)));
        }

        [HttpPut("SetAsActive/{id}")]
        public async Task<ActionResult<Models.Task>> SetAsActive(string id)
        {
            return await HandleRequest(async () => await repository.SetAsActive(Guid.Parse(id)));
        }
    }
}
