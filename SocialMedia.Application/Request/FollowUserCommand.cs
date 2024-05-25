using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Request
{
    public class FollowUserCommand : IRequest
    {
        public string UserId { get; set; }
        public string FollowUserId { get; set; }
    }
}
