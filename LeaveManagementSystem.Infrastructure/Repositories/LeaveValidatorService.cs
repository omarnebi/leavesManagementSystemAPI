using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Infrastructure.Repositories
{
    public class LeaveValidatorService : ILeaveValidatorService
    {
        private readonly AppDbContext _context;

        public LeaveValidatorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ValidateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            //No overlapping dates
            var overlapping = await _context.LeaveRequests
                .AnyAsync(l =>
                    l.EmployeeId == leaveRequest.EmployeeId &&
                    l.Id != leaveRequest.Id &&
                    l.StartDate < leaveRequest.EndDate &&
                    l.EndDate > leaveRequest.StartDate);

            if (overlapping)
                throw new Exception("Overlapping leave dates for this employee.");

            // Max 20 annual leave days per year
            if (leaveRequest.LeaveType == LeaveType.Annual)
            {
                int year = leaveRequest.StartDate.Year;
                var totalDays = await _context.LeaveRequests
                    .Where(l => l.EmployeeId == leaveRequest.EmployeeId &&
                                l.LeaveType == LeaveType.Annual &&
                                l.StartDate.Year == year)
                    .SumAsync(l => (l.EndDate - l.StartDate).Days);

                int newDays = (leaveRequest.EndDate - leaveRequest.StartDate).Days;
                if (totalDays + newDays > 20)
                    throw new Exception("Annual leave days exceeded (max 20 days/year).");
            }

            //Sick leave requires a reason
            if (leaveRequest.LeaveType == LeaveType.Sick && string.IsNullOrWhiteSpace(leaveRequest.Reason))
            {
                throw new Exception("Sick leave requires a reason.");
            }
        }
    }
}
