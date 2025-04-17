using LeaveManagementSystem.Application.DTOs;
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
    public async Task<List<LeaveRequest>> FilterAsync(LeaveRequestFilterDto filters)
    {
        var query = _context.LeaveRequests
            .Include(l => l.Employee)
            .AsQueryable();

        if (filters.EmployeeId.HasValue)
            query = query.Where(l => l.EmployeeId == filters.EmployeeId.Value);

        if (filters.LeaveType.HasValue)
            query = query.Where(l => l.LeaveType == filters.LeaveType.Value);

        if (filters.Status.HasValue)
            query = query.Where(l => l.Status == filters.Status.Value);

        if (filters.StartDate.HasValue)
            query = query.Where(l => l.StartDate >= filters.StartDate.Value);

        if (filters.EndDate.HasValue)
            query = query.Where(l => l.EndDate <= filters.EndDate.Value);

        if (!string.IsNullOrEmpty(filters.Search))
            query = query.Where(l => l.Reason != null && l.Reason.ToLower().Contains(filters.Search.ToLower()));

        if (!string.IsNullOrEmpty(filters.SortBy))
        {
            query = filters.SortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(l => EF.Property<object>(l, filters.SortBy))
                : query.OrderBy(l => EF.Property<object>(l, filters.SortBy));
        }

        int skip = (filters.Page - 1) * filters.PageSize;
        return await query.Skip(skip).Take(filters.PageSize).ToListAsync();
    }
}
