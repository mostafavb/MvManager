using MediatR;
using SC.App.Application.DTOs.LeaveRequest;

namespace SC.App.Application.Features.LeaveRequests.Requests.Queries;
public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
{    
}
