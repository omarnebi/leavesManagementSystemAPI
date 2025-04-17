using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.DTOs
{
    public class LeaveRequestFilterDto
    {
    public int? EmployeeId { get; set; }
    public LeaveType? LeaveType { get; set; }
    public LeaveStatus? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string? Search { get; set; }

    public string? SortBy { get; set; } = "StartDate";
    public string? SortOrder { get; set; } = "asc";

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    }
}

