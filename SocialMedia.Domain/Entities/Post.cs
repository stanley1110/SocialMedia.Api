using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Post
    {
        [BsonId]
        public string Id { get; set; }
        [BsonRequired]
        public string UserId { get; set; }
        [BsonRequired]
        [StringLength(140, MinimumLength = 5)]
        public string Text { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
    }
}
