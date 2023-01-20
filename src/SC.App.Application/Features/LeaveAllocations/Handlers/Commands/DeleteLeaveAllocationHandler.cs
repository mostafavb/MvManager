using MediatR;
using SC.App.Application.Features.LeaveAllocations.Requests.Commands;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveAllocations.Handlers.Commands;
public class DeleteLeaveAllocationHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository leaveAllocationRepository;

    public DeleteLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leavAllocation = await leaveAllocationRepository.Get(request.Id);
        await leaveAllocationRepository.Delete(leavAllocation);
        return Unit.Value;
    }
}
