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

    public LeaveRequestsController(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

}
