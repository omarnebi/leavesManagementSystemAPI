using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Interfaces
{
    public interface ILeaveValidatorService
    {
        Task ValidateLeaveRequestAsync(LeaveRequest leaveRequest);
    }
}
