using backend.Models;
using backend.Repositories;
using MongoDB.Driver;

namespace backend.Helpers
{
    public class CreateDatabase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        public CreateDatabase(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task InitializeDatabase()
        {
            await CreateUsers();

        }

        public async System.Threading.Tasks.Task CreateUsers()
        {
            List<User> users = new List<User>();
            users.Add(CreateUser("Kasper Pettersen"));
            users.Add(CreateUser("Trym Hansen"));
            users.Add(CreateUser("Nathalie Sletten"));
            users.Add(CreateUser("Magnus Berg"));
            users.Add(CreateUser("Alina Svendsen"));
            users.Add(CreateUser("Matilde Vatne"));
            users.Add(CreateUser("Olav Stang"));
            users.Add(CreateUser("Tony Stølen"));
            users.Add(CreateUser("Synnøve Holmen"));
            users.Add(CreateUser("Eivind Stokkeland"));
            users.Add(CreateUser("Henrik Skeie"));
            users.Add(CreateUser("Synne Sandal"));
            users.Add(CreateUser("Isac Sandbakken"));
            users.Add(CreateUser("Even Hoff"));
            users.Add(CreateUser("Nicolay Vågen"));
            users.Add(CreateUser("Elise Sollie"));
            users.Add(CreateUser("Dennis Pettersen"));
            users.Add(CreateUser("Ivar Stien"));
            users.Add(CreateUser("Julie Karlsson"));
            users.Add(CreateUser("Caroline Tangen"));
            users.Add(CreateUser("Gunnar", Guid.Parse("11111111-1111-1111-1111-111111111111")));

            await _userRepository.BulkUpsert(users);
        }

        private User CreateUser(string name, Guid? id = null)
        {
            return new User()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Name = name,
                BestMonthlyScore = GenerateRandomNumberOfTimes(60),
                ThisMonthsScore = GenerateRandomNumberOfTimes(20),
                ThisWeeksScore = GenerateRandomNumberOfTimes(5),
                ThisYearsScore = GenerateRandomNumberOfTimes(200),
            };
        }

        public int GenerateRandomTaskScore()
        {
            int retVal = 0;
            Random random = new Random();
            for(int i = 0; i < 5; i++)
            {
                int f = random.Next(1, 5);
                retVal += f;
            }           
            retVal = retVal * 10;
            return retVal;
        }

        public int GenerateRandomNumberOfTimes(int count)
        {
            int RetVal = 0;
            for (int i = 0; i < count; i++)
            {
                RetVal += GenerateRandomTaskScore();
            }
            return RetVal;
        }
    }
}
