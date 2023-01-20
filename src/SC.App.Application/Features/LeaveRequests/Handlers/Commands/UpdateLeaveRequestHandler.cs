using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveRequest;
using SC.App.Application.DTOs.LeaveRequest.Validators;
using SC.App.Application.Exceptions;
using SC.App.Application.Features.LeaveRequests.Requests.Commands;
using SC.App.Application.Contracts.Persistence;
using SC.App.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SC.App.Application.Features.LeaveRequests.Handlers.Commands;
public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _unitOfWork.LeaveRequestRepository.Get(request.Id);

        if (leaveRequest is null)
            throw new NotFoundException(nameof(leaveRequest), request.Id);

        if (request.LeaveRequestDto != null)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (validationResult.IsValid == false)
                throw new Exceptions.ValidationException(validationResult);

            _mapper.Map(request.LeaveRequestDto, leaveRequest);

            await _unitOfWork.LeaveRequestRepository.Update(leaveRequest);
        }
        else if (request.ChangeLeaveRequestApprovalDto != null)
        {
            if (request.ChangeLeaveRequestApprovalDto.Approved)
            {
                var allocations = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequestd = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocations.NumberOfDays = daysRequestd;
                await _unitOfWork.LeaveAllocationRepository.Update(allocations);
            }

        }
        
        await _unitOfWork.Save();
        return Unit.Value;
    }
}
