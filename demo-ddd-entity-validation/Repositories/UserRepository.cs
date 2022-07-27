using demo_ddd_entity_validation.Entities;
using demo_ddd_entity_validation.Enums;

namespace demo_ddd_entity_validation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new();
        }

        public Task<string> Create(User user)
        {
            if (_users.Any(token => token.Email == user.Email))
            {
                return Task.FromResult(nameof(CreateUserEnum.AlreadyExists));
            }

            _users.Add(user);

            return Task.FromResult(nameof(CreateUserEnum.Created));
        }
    }
}
