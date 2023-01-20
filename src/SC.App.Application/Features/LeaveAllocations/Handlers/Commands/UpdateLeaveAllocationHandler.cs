using AutoMapper;
using MediatR;
using SC.App.Application.Features.LeaveAllocations.Requests.Commands;
using SC.App.Application.Contracts.Persistence;
using SC.App.Domain.Entities;

namespace SC.App.Application.Features.LeaveAllocations.Handlers.Commands;
public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository leaveAllocationRepository;
    private readonly IMapper mapper;

    public UpdateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        await leaveAllocationRepository.Update(mapper.Map<LeaveAllocation>(request.LeaveAllocationDto));
        return Unit.Value;
    }
}
