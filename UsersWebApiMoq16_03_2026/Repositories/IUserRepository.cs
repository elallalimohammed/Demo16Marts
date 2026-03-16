using UsersWebApiMoq16_03_2026.Models;

namespace UsersWebApiMoq16_03_2026.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        // New method
        Task<User> LoginAsync(string username, string password);
    }
}
