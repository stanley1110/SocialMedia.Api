using MediatR;
using SocialMedia.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.DTO
{
    public class FollowUserCommandDto
    {
        [Required]
        public required string FollowUserId { get; set; }
    }
}
