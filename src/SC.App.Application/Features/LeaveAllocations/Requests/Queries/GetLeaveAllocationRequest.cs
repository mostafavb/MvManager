using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;

namespace SC.App.Application.Features.LeaveAllocations.Requests.Queries;
public class GetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}
