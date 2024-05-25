using MediatR;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Request
{
    public class GetFeedQuery : IRequest<List<Post>>
    {
        public required string UserId { get; set; }
        public required int PageNumber { get; set; }
        public required int PageSize { get; set; }
    }
}
