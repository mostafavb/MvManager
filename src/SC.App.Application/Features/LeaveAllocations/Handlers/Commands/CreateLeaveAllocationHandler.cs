using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveAllocation;
using SC.App.Application.Features.LeaveAllocations.Requests.Commands;
using SC.App.Application.Contracts.Persistence;
using SC.App.Domain.Entities;

namespace SC.App.Application.Features.LeaveAllocations.Handlers.Commands;
public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, LeaveAllocationDto>
{
    private ILeaveAllocationRepository leaveAllocationRepository;
    private IMapper mapper;

    public CreateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.mapper = mapper;
    }


    public async Task<LeaveAllocationDto> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {

        var leaveAllocation = await leaveAllocationRepository.Add(mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto));
        return mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}
