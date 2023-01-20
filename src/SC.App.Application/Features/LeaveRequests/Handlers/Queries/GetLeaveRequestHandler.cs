using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveRequest;
using SC.App.Application.Features.LeaveRequests.Requests.Queries;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveRequests.Handlers.Queries;
public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequestRequest, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository leaveRequestRepository;
    private readonly IMapper mapper;

    public GetLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        this.leaveRequestRepository = leaveRequestRepository;
        this.mapper = mapper;
    }
    public async Task<LeaveRequestDto> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var leaaveRequest = await leaveRequestRepository.Get(request.Id);
        return mapper.Map<LeaveRequestDto>(leaaveRequest);
    }
}
