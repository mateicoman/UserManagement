using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class CreateDepartmentRequest
	{
		[Required]
		public string? DepartmentName { get; init; }
	}
}

