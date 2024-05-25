using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using SocialMedia.Application.Exceptions;
using SocialMedia.Application.Interface;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _post;

        public PostRepository(IMongoDatabase database)
        {
            _post = database.GetCollection<Post>("Post");
        }

        public async Task AddPostAsync(Post  post)
        {
            await _post.InsertOneAsync(post);
        }
        public async Task LikePost( string postid)
        {
            var postfilter = Builders<Post>.Filter.Eq(a => a.Id,postid);
            var post =  await _post.FindAsync(postfilter);
            if (await post.FirstOrDefaultAsync() == null)
            {
                throw new NotFoundException($"Post with id {postid} not found.");
            }
            var filter = Builders<Post>.Filter.Eq(a=> a.Id, postid);
            var update = Builders<Post>.Update.Inc(p => p.Likes, 1);


             await _post.UpdateOneAsync(filter, update);
        }

        public async Task<List<Post>> GetPostsByUserIdsAsync(HashSet<string> UserIdFollowing, int PageNumber, int PageSize)
        {
            var filter = Builders<Post>.Filter.In(a => a.UserId, UserIdFollowing);
            var sort = Builders<Post>.Sort.Descending(c => c.Likes);

            var data = await _post.Find(filter)
            .Sort(sort)
                .Skip((PageNumber - 1) * PageSize)
                .Limit(PageSize)
                .ToListAsync();
            return data;
        }
    }
    
}
