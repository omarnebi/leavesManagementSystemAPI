using AutoMapper;
using LeaveManagementSystem.Application.DTOs;
using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeaveManagementSystem.Application.Mappings
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName));
            CreateMap<CreateLeaveRequestDto, LeaveRequest>();
            CreateMap<UpdateLeaveRequestDto, LeaveRequest>();
        }
    }
}
