using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;
using SC.App.Application.Features.LeaveAllocations.Requests.Queries;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveAllocations.Handlers.Queries;
public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository leaveAllocationRepository;
    private readonly IMapper mapper;

    public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await leaveAllocationRepository.GetAll();


        return mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
    }
}
