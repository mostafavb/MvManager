using MediatR;
using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}