using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);

    }
}
