using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>>GetAllUsers();
    }
    public class UsersService : IUsersService//bu yapı bizdeki manager galiba
    {
        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
