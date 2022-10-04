using backend.Models;
using backend.Repositories;
using MongoDB.Driver;

namespace backend.Helpers
{
    public class CreateDatabase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly Random random = new Random();
        public CreateDatabase(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task InitializeDatabase()
        {
            await CreateUsers();
            await CreateTasks();
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

        public async System.Threading.Tasks.Task CreateTasks()
        {
            List<Models.Task> tasks = new List<Models.Task>();
            tasks.Add(CreateTask("Leaky tap", "Kitchen tap is dripping", "Vanessa Ellingsen", "Gamle Kalvedalsveien 15", 5019, "BERGEN"));
            tasks.Add(CreateTask("Soap stuck in drain", "Soap is stuck in drain in upstairs bathroom sink", "Guro Lorentzen", "Bergithe Hansens vei 119", 8624, "MO I RANA"));
            tasks.Add(CreateTask("Leaky toilet", "Toilet  continuously flushes", "Malin Frøseth", "Østre vegsundrabben 104", 6020, "ÅLESUND"));
            tasks.Add(CreateTask("Frozen pipes", "No water upstairs due to frozen pipes", "Isabel Bråthen", "Tordenskjolds gate 93", 8656, "MOSJØEN"));
            tasks.Add(CreateTask("Basement flooded", "Leak from pipe has flooded the basement", "Ingvild Aasen", "Slinningsodden 38", 6006, "ÅLESUND"));
            tasks.Add(CreateTask("Install dish washer", "Need help hooking up dish washer", "Sofia Sørvik", "Sørliveien 102", 9018, "TROMSØ"));
            tasks.Add(CreateTask("Low water pressure", "Garden tap has very low water pressure", "Steffen Oterhals", "Rommetveitvegen 134", 5414, "STORD"));
            tasks.Add(CreateTask("Install new stall shower", "Remove old shower and install new one in bathroom", "Albert Ulland", "Olav Oksviks veg 73", 6425, "MOLDE"));
            tasks.Add(CreateTask("Change water heater", "Deliver and install new water heater", "Hilde Bjørgum", "Borgarhaugvegen 194", 6091, "FOSNAVÅG"));
            tasks.Add(CreateTask("Clogged toilet", "Toilet is clogged. Water overflowing to floor", "Torjus Olsen", "Peter Solemdals veg 56", 6414, "MOLDE"));

            tasks[0].State = States.Reserved;
            tasks[0].OwnerId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            tasks[1].State = States.Reserved;
            tasks[1].OwnerId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            await _taskRepository.BulkUpsert(tasks);
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
                OverallScore = GenerateRandomNumberOfTimes(1000),
                Achievements = CreateAchievements(),
            };
        }

        private Achievement[] CreateAchievements()
        {
            List<Achievement> achievements = new List<Achievement>();
            int limit = random.Next(0,6);
            for (int i = 0; i < limit; i++)
            {
                Achievement achievement = new Achievement()
                {
                    Name = achievementNames[random.Next(0, 10)],
                    DateAchieved = DateTime.UtcNow.AddDays(random.Next(-300, 0)),
                    Type = (AchievementType)random.Next(0, 3),
                };
                achievements.Add(achievement);
            }
            return achievements.ToArray();
        }

        List<string> achievementNames = new List<string>()
        {
            "Speedy",
            "Busy",
            "Magician",
            "Friendly",
            "Trusted",
            "City life enthusiast",
            "Night owl",
            "Country side lover",
            "Freshmen",
            "Well oriented"
        };

        private Models.Task CreateTask(string title, string description, string customer, string street, int postCode, string city)
        {
            Models.Task task = new()
            {
                Title = title,
                Description = description,
                Customer = customer,
                Address = new()
                {
                    Street = street,
                    City = city,
                    PostalCode = postCode
                },
                Score = GenerateRandomTaskScore(),
                State = States.New,
                EstimatedTime = random.Next(1, 8) / 2m,
                Id = Guid.NewGuid(),
            };
            return task;
        }

        public int GenerateRandomTaskScore()
        {
            int retVal = 0;
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
