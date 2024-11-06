using API.Models;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);

        Task<List<User>> GetAllUser();
        Task<User> AddUser(User user);

        Task UpdateUser(User user);

        Task<bool> DeleteUser(int userId);
        Task<User> GetUserByUserId(int userId);
    }
}
