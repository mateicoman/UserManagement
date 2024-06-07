using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs.Department
{
	public class DepartmentPostDto
	{
		[Required]
		public string? DepartmentName { get; init; }
	}
}

