using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs.Employee
{
	public class EmployeePutDto
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

