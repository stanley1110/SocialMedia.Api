using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.DTO
{
    public class PostDto
    {
        [Required,MaxLength(140)]
        public  string post {  get; set; }  
    }
}
