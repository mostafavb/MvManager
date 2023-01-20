using MediatR;
using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
{
}