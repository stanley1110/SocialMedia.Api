using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.DTO;
using SocialMedia.Application.Request;
using System.Security.Claims;

namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FollowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Follow(FollowUserCommandDto  commandDto)
        {
            FollowUserCommand command = new FollowUserCommand() { UserId = await GetcurrentUser(), FollowUserId = commandDto.FollowUserId };
            await _mediator.Send(command);
            return Ok();
        }
        private async Task<string> GetcurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return identity?.Claims?.FirstOrDefault(o => o.Type == "UserId").Value;
            }
            return string.Empty;
        }
    }

}
