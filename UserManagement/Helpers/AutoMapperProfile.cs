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
			CreateMap<CreateDepartmentRequest, DepartmentModel>();
            CreateMap<CreateSiteRequest, SiteModel>();
            CreateMap<CreateEmployeeRequest, EmployeeModel>();

			CreateMap<UpdateDepartmentRequest, DepartmentModel>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<UpdateSiteRequest, SiteModel>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<UpdateEmployeeRequest, EmployeeModel>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
 					}
				));
        }
	}
}

