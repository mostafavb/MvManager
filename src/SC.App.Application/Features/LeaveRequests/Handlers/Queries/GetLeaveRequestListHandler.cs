using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveRequest;
using SC.App.Application.Features.LeaveRequests.Requests.Queries;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveRequests.Handlers.Queries;
public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository leaveRequestRepository;
    private readonly IMapper mapper;

    public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository,IMapper mapper)
    {
        this.leaveRequestRepository = leaveRequestRepository;
        this.mapper = mapper;
    }
    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequests = await leaveRequestRepository.GetAll();
        return mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
    }
}
