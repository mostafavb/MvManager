using MediatR;
using SC.App.Application.DTOs.LeaveRequest;
using SC.App.Application.Responses;

namespace SC.App.Application.Features.LeaveRequests.Requests.Commands;
public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveRequestDto LeaveRequestDto { get; set; }

}
