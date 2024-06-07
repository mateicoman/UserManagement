using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs.Site
{
	public class SitePostDto
	{
		[Required]
		public string? SiteName { get; init; }
	}
}

