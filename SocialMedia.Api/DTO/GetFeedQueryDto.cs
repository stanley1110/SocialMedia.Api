using MediatR;
using SocialMedia.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.DTO
{
    public class GetFeedQueryDto
    {
        [Required]
        public  int PageNumber { get; set; }
        [Required]
        public required int PageSize { get; set; }
    }
}
