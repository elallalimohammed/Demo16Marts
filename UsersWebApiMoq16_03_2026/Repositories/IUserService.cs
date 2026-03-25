using UsersWebApiMoq16_03_2026.Models;

namespace UsersWebApiMoq16_03_2026.Repositories
{
    public interface IUserService
    {
        Task<User> GetUserById(string userId);   // plus the other methods}

    }
}
