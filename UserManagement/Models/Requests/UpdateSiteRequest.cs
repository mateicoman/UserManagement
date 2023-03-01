using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class UpdateDepartmentRequest
	{
		[Required]
		public string? DepartmentName { get; init; }
	}
}

