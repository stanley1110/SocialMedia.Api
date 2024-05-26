using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialMedia.Api.DTO;
using SocialMedia.Application.Queries;
using SocialMedia.Application.Request;
using System.Security.Claims;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
 
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostDto post)
        {
            CreatePostCommand command = new CreatePostCommand()
            {
                UserId = await GetcurrentUser(),
                Text = post.post
            };
            
            var postId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFeed),new { PostId = postId });
        }

        [HttpPost("likePost")]
        public async Task<IActionResult> LikePost( string postidDto)
        {
            LikePostCommand likePost = new LikePostCommand() { postid = postidDto};
            await _mediator.Send(likePost);
            return Ok();
        }

        [HttpGet("feed")]
        public async Task<IActionResult> GetFeed([FromQuery] GetFeedQueryDto queryDto)
        {
            GetFeedQuery query = new GetFeedQuery() { PageNumber = queryDto.PageNumber, PageSize=queryDto.PageSize, UserId= await GetcurrentUser() };
            var feed = await _mediator.Send(query);
            return Ok(feed);
        }

        private async Task<string> GetcurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return  identity?.Claims?.FirstOrDefault(o => o.Type == "UserId").Value;
            }
            return string.Empty;
        }
    }

}
