using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;

namespace SC.App.Application.Features.LeaveAllocations.Requests.Commands;
public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public LeaveAllocationDto LeaveAllocationDto { get; set; }
}
