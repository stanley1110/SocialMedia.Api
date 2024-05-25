using MediatR;
using SocialMedia.Application.Exceptions;
using SocialMedia.Application.Interface;
using SocialMedia.Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.RequestHandler
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public FollowUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            if (user.Following.Contains(request.FollowUserId)) { throw new BadRequestException($"User {request.UserId} already follows user {request.FollowUserId}"); }
            user.Following.Add(request.FollowUserId);
            await _userRepository.UpdateUserAsync(user);
            return;
        }
    }
}
