using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.DTOs
{
    public class CreateLeaveRequestDto
    {
        public int EmployeeId { get; set; }
        public LeaveType? LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LeaveStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}
