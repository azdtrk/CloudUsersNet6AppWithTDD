using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services.Abstractions
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
}
