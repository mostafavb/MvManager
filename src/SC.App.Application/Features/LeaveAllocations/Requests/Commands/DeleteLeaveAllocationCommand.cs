using MediatR;

namespace SC.App.Application.Features.LeaveAllocations.Requests.Commands;
public class DeleteLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
