using Amazon.Runtime.Internal.Util;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SocialMedia.Application.Exceptions;
using SocialMedia.Application.Interface;
using SocialMedia.Application.Request;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.RequestHandler
{
    public class GetFeedQueryHandler : IRequestHandler<GetFeedQuery, List<Post>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;

        public GetFeedQueryHandler(IPostRepository postRepository, IUserRepository userRepository, IMemoryCache memoryCache)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<Post>> Handle(GetFeedQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User with {request.UserId} not found.");
            }
            try
            {
                string cacheKey = $"PaginatedData__{request.UserId}_{request.PageNumber}_{request.PageSize}";
                var posts = await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5); // Optional: set cache expiration
                    return await _postRepository.GetPostsByUserIdsAsync(user.Following, request.PageNumber, request.PageSize);
                });

                return posts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
        }
    }
}
