using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Interface
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post);
        Task<List<Post>> GetPostsByUserIdsAsync(HashSet<string> UserIdFollowing, int PageNumber, int PageSize);
        Task LikePost( string postid);
    }
}