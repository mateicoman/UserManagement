﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }
        public string? Forename { get; init; }
        public string? Surname { get; init; }
        public string? Username { get; init; }
        public int DepartmentId { get; init; }
        public int SiteId { get; init; }
        public string? PhotoFileName { get; set; }
    }
}

