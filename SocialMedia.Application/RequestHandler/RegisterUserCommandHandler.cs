using MediatR;
using MongoDB.Driver;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            HashSet<string> followingList = new HashSet<string>()
            {
                id
            };
           
            var user = new User
            {
                Id = id,
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                 Following = followingList
            };
            try
            {
                await _userRepository.AddUserAsync(user);
            }
            catch (MongoWriteException ex)
            {
                if (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    throw new BadRequestException($"Username {user.Username} already exists. Please choose another one.");
                }
                else
                {
                    throw ex;
                }
            }

            return user.Id;
        }
    }
}
