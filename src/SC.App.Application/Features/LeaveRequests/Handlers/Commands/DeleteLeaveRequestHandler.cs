using MediatR;
using SC.App.Application.Features.LeaveRequests.Requests.Commands;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveRequests.Handlers.Commands;
public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository leaveRequestRepository;

    public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        this.leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await leaveRequestRepository.Get(request.Id);
        await leaveRequestRepository.Delete(leaveRequest);
        return Unit.Value;
    }
}
