using MediatR;
using SC.App.Application.DTOs.LeaveRequest;

namespace SC.App.Application.Features.LeaveRequests.Requests.Commands;
public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public UpdateLeaveRequestDto LeaveRequestDto { get; set; } = new();
    public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApprovalDto { get; set; }
}
