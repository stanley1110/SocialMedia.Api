using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Request
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
