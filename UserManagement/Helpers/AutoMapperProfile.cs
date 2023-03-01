using System;
using AutoMapper;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Helpers
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CreateDepartmentRequest, Department>();
            CreateMap<CreateSiteRequest, Site>();
            CreateMap<CreateEmployeeRequest, Employee>();
        }
	}
}

