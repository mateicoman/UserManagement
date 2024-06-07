using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Domain.DTOs.Site
{
    public class SiteDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        public string? SiteName { get; init; }
    }
}

