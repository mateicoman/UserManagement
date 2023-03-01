using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class CreateSiteRequest
	{
		[Required]
		public string? SiteName { get; init; }
	}
}

