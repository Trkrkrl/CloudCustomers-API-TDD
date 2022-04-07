using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }
    public class UsersService : IUsersService//bu yapı bizdeki manager galiba
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            //İLK olarak geçebilmesi için gerekli minimum miktarda kod yaz
            var response = await _httpClient.GetAsync("http://example.com");//http clientin bir requet url vermesini bekle-olmadığı için şimdilik example
            return new List<User> { };
        }
    }
}