using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Request
{
    public class CreatePostCommand : IRequest<string>
    {
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
