using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveType;
using SC.App.Application.Features.LeaveTypes.Requests.Queries;
using SC.App.Application.Contracts.Persistence;

namespace SC.App.Application.Features.LeaveTypes.Handlers.Queries;
public class GetLeaveTypeListHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository leaveTypeRepository;
    private readonly IMapper mapper;

    public GetLeaveTypeListHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        this.leaveTypeRepository = leaveTypeRepository;
        this.mapper = mapper;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypes = await leaveTypeRepository.GetAll();
        return mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
}
