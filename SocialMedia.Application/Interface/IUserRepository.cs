using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Interface
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);


        Task<User> GetUserByUsernameAsync(string username);

        Task<User> GetUserByIdAsync(string id);
        Task UpdateUserAsync(User user);
    }
}