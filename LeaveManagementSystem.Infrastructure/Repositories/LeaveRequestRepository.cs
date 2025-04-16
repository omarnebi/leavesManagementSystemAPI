using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

using System;

namespace LeaveManagementSystem.Infrastructure.Repositories;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly AppDbContext _context;

    public LeaveRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LeaveRequest>> GetAllAsync() =>
        await _context.LeaveRequests.Include(l => l.Employee).ToListAsync();

    public async Task<LeaveRequest?> GetByIdAsync(int id) =>
        await _context.LeaveRequests.Include(l => l.Employee).FirstOrDefaultAsync(l => l.Id == id);

    public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
    {
        leaveRequest.CreatedAt = DateTime.UtcNow;
       
          _context.LeaveRequests.Add(leaveRequest);
        await _context.SaveChangesAsync();
        return leaveRequest;
    }

    public async Task UpdateAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var leave = await _context.LeaveRequests.FindAsync(id);
        if (leave != null)
        {
            _context.LeaveRequests.Remove(leave);
            await _context.SaveChangesAsync();
        }
    }
}
