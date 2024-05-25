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
    public class LikePostCommandHandler : IRequestHandler<LikePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public LikePostCommandHandler(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(LikePostCommand request, CancellationToken cancellationToken)
        {


            await _postRepository.LikePost(request.postid);
            return;
          
        }
    }
}
