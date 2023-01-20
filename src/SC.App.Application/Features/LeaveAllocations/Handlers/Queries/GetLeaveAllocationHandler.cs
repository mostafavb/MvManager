using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;
using SC.App.Application.Features.LeaveAllocations.Requests.Queries;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveAllocations.Handlers.Queries;
public class GetLeaveAllocationHandler : IRequestHandler<GetLeaveAllocationRequest, LeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository leaveAllocationRepository;
    private readonly IMapper mapper;

    public GetLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.mapper = mapper;
    }
    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await leaveAllocationRepository.Get(request.Id);
        return mapper.Map<LeaveAllocationDto>(leaveAllocation);

    }
}
