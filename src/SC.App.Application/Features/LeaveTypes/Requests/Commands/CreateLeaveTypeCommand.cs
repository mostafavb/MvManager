using MediatR;
using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.Features.LeaveTypes.Requests.Commands;
public class CreateLeaveTypeCommand //: IRequest<BaseCommandResponse>
{
    public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }

}