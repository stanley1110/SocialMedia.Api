using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonRequired]
        public string PasswordHash { get; set; }
        public HashSet<string> Following { get; set; } = new HashSet<string>();
    }
}
