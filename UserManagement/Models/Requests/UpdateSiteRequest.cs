using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
	public class UpdateSiteRequest
	{
		public string? SiteName { get; init; }
	}
}

