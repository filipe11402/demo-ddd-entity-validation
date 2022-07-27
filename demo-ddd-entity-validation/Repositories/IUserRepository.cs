using demo_ddd_entity_validation.Entities;

namespace demo_ddd_entity_validation.Repositories
{
    public interface IUserRepository
    {
        Task<string> Create(User user);
    }
}
