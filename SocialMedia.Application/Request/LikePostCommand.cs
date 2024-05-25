using MediatR;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Request
{
    public class LikePostCommand : IRequest
    {
       
        public required string postid { get; set; }

    }
}
