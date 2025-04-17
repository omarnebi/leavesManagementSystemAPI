using AutoMapper;
using LeaveManagementSystem.Application.DTOs;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace LeaveManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestsController : ControllerBase
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILeaveValidatorService _validator;

    public LeaveRequestsController(ILeaveRequestRepository repository, IMapper mapper, ILeaveValidatorService validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var leaves = await _repository.GetAllAsync();
        var result = _mapper.Map<List<LeaveRequestDto>>(leaves);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var leave = await _repository.GetByIdAsync(id);
        return leave == null ? NotFound() : Ok(_mapper.Map<LeaveRequestDto>(leave));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLeaveRequestDto dto)
    {
        var leave = _mapper.Map<LeaveRequest>(dto);
        await _validator.ValidateLeaveRequestAsync(leave);
        var created = await _repository.AddAsync(leave);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.Map<LeaveRequestDto>(created));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLeaveRequestDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return NotFound();
        _mapper.Map(dto, existing);

        await _repository.UpdateAsync(existing);
        return NoContent(); 
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] LeaveRequestFilterDto filters)
    {
        var results = await _repository.FilterAsync(filters);
        var dtos = _mapper.Map<List<LeaveRequestDto>>(results);
        return Ok(dtos);
    }

    [HttpGet("report")]
    public async Task<IActionResult> GetReport([FromQuery] int year, [FromQuery] string? department, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var report = await _repository.GetLeaveReportAsync(year, department, startDate, endDate);
        return Ok(report);
    }

    [HttpPost("{id}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        var success = await _repository.ApproveLeaveRequestAsync(id);
        if (!success) return BadRequest("Invalid leave request or already approved.");
        return Ok("Leave approved successfully.");
    }


}
