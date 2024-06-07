using UserManagement.Domain.DTOs.Department;
using UserManagement.Domain.DTOs.Employee;
using UserManagement.Domain.DTOs.Site;

namespace UserManagement.Helpers
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<DepartmentPostDto, DepartmentDto>();
            CreateMap<SitePostDto, SiteDto>();
            CreateMap<EmployeePostDto, EmployeeDto>();

			CreateMap<DepartmentPutDto, DepartmentDto>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<SitePutDto, SiteDto>()
				.ForAllMembers(x => x.Condition(
					(src, dest, prop) =>
					{
						if (prop == null) return false;
						if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

						return true;
					}
				));
			CreateMap<EmployeePutDto, EmployeeDto>()
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

