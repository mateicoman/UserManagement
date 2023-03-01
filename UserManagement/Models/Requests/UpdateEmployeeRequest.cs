using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class UpdateEmployeeRequest
	{
        public string? Forename { get; init; }
        public string? Surname { get; init; }
        public string? Username { get; init; }
        public int DepartmentId { get; init; }
        public int SiteId { get; init; }
        [EmailAddress]
        public string? Email { get; init; }
        public string? PhotoFileName { get; set; }
    }
}

