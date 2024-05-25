using MediatR;
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
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, string>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow,
                Likes = 0
            };

            await _postRepository.AddPostAsync(post);
            return post.Id;
        }
    }
}
