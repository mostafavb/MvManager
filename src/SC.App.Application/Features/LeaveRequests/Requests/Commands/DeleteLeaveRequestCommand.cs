using MediatR;
using SC.App.Application.DTOs.LeaveRequest;

namespace SC.App.Application.Features.LeaveRequests.Requests.Commands;
public class DeleteLeaveRequestCommand : IRequest<Unit>
{
    public int Id{ get; set; }
}
