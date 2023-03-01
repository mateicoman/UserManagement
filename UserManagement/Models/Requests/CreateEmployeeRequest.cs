using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class CreateEmployeeRequest
	{
        [Required]
        public string? Forename { get; init; }
        [Required]
        public string? Surname { get; init; }
        [Required]
        public string? Username { get; init; }
        [Required]
        public string? DepartmentId { get; init; }
        [Required]
        public string? SiteId { get; init; }
        [Required]
        [EmailAddress]
        public string? Email { get; init; }
        public string? PhotoFileName { get; set; }
    }
}

