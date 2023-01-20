using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;

namespace SC.App.Application.Features.LeaveAllocations.Requests.Commands;
public class CreateLeaveAllocationCommand : IRequest<LeaveAllocationDto>
{
    public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; } = new();
}
