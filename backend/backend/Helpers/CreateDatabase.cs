using backend.Models;
using backend.Repositories;
using MongoDB.Driver;

namespace backend.Helpers
{
    public class CreateDatabase
    {
        private readonly IUserRepository _userRepository;
        public CreateDatabase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.BulkUpsert(users);
        }

        private User CreateUser(string name)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Name = name,

            };
        }
    }
}
