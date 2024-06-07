using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Domain.DTOs.Department
{
    public record DepartmentDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        [BsonElement("Name")]
        public string? DepartmentName { get; init; }
    }
}

