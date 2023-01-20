using MediatR;
using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.Features.LeaveTypes.Requests.Commands;
public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public LeaveTypeDto LeaveTypeDto { get; set; }

}