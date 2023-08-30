using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;
using Geolocation;

namespace CarValetAPI2.Shared.Helper
{
    public static class Mapper
    {
        public static CompanyDto MapCompanyDto(Company company, Owner owner, Service service)
        {
            return new CompanyDto
            {
                Address = company.Address,
                CompanyName = company.CompanyName,
                Location = company.Location,
                ServiceDay = company.ServiceDay,
                Owner = company.Owner,
                Service = company.Service
            };
        }

        public static Company GetCompanyFromDto(CompanyDto companyDto)
        {
            return new Company
            {
                Owner = companyDto.Owner,
                Service = companyDto.Service,
                WorkingHours = companyDto.WorkingHours,
                Address = companyDto.Address,
                CompanyName = companyDto.CompanyName,
                CompanyId = companyDto.CompanyId,
                Location = companyDto.Location,
                ServiceDay = companyDto.ServiceDay
            };
        }

        public static Owner GetOwnerFromDto(CompanyDto companyDto)
        {
            return new Owner
            {
                OwnerId = companyDto.Owner?.OwnerId,
                Email = companyDto.Owner?.Email,
                Mobile = companyDto.Owner?.Mobile,
                Name = companyDto.Owner?.Name,
                Password = companyDto.Owner?.Password
            };
        }

        public static List<Service>? GetServiceFromDto(CompanyDto companyDto)
        {
            if (companyDto.Service != null)
            {
                return companyDto.Service.Select(x => new Service
                {
                    EstimatedTime = x.EstimatedTime,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    ServiceId = x.ServiceId
                }).ToList();
            }
            return null;
        }

        public static List<Staff>? GetStaffsFromDto(CompanyDto companyDto)
        {
            if (companyDto.Staffs != null)
            {
                return companyDto.Staffs.Select(x => new Staff
                {
                    Email = x.Email,
                    Name = x.Name,
                    Password = x.Password,
                    StaffId = x.StaffId,
                    Shift = x.Shift
                }).ToList();
            }
            return null;
        }

        public static CompanyDto GetCompanyDtoFromRequest(RequestObj request)
        {
            return new CompanyDto
            {
                Address = request?.Useobj?.Address,
                CompanyName = request?.Useobj?.BusinessName,
                Owner = new Owner
                {
                    Email = request.Useobj.Email,
                    Mobile = request.Useobj.Mobile,
                    Name = request.Useobj.Name,

                },
                Service = request.ServiceObj.Select(x => new Service
                {
                    Description = x.Description,
                    EstimatedTime = x.EstimatedTime,
                    Name = x.ServiceName,
                    Price = x.Price.ToString(),
                }).ToList(),
                WorkingHours = request.WorkingHoursObj.Select(x => new WorkingHour
                {
                    Day = x.Day,
                    Id = x.Id,
                    IsAvailable = x.IsAvailable,
                    From = DateTime.Parse(x.From),
                    To = DateTime.Parse(x.To)
                }).ToList(),
                Location = new Coordinate(request.LocationObj.Lat, request.LocationObj.Long)
            };
        }

        public static Staff GetStaffFromDto(StaffDto staffDto)
        {
            return new Staff
            {
                CompanyId = staffDto.CompanyId,
                Email = staffDto.Email,
                Name = staffDto.Name,
                Password = staffDto.Password,
                Expertise = staffDto.Expertise,
                Mobile = staffDto.Mobile,
                Shift = staffDto.Shift.Select(x => new Shift
                {
                    Day = x.Day,
                    From = DateTime.Parse(x.From),
                    To = DateTime.Parse(x.To),
                    IsAvailable = x.IsAvailable,
                    Id = x.Id
                }).ToList()
            };
        }
    }
}