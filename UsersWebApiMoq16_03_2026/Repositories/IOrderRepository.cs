using UsersWebApiMoq16_03_2026.Models;

namespace UsersWebApiMoq16_03_2026.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
    }
}
