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

			CreateMap<UpdateDepartmentRequest, Department>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<UpdateSiteRequest, Site>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<UpdateEmployeeRequest, Employee>()
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

