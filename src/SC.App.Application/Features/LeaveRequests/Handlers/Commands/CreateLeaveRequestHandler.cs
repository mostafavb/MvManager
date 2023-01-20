using AutoMapper;
using MediatR;
using SC.App.Application.DTOs.LeaveRequest;
using SC.App.Application.Features.LeaveRequests.Requests.Commands;
using SC.App.Application.Features.LeaveRequests.Requests.Queries;
using SC.App.Application.Contracts.Persistence;
using SC.App.Domain.Entities;
using SC.App.Application.Contracts.Infrastructure;
using SC.App.Application.Responses;
using SC.App.Application.DTOs.LeaveRequest.Validators;
using SC.App.Application.Models;
using System.Security.Claims;

namespace SC.App.Application.Features.LeaveRequests.Handlers.Commands;
public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
        var userId = "MVB";
        var allocation = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(userId, request.LeaveRequestDto.LeaveTypeId);

        if (allocation is null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDto.LeaveTypeId),
                "You do not have any allocations for this leave type."));
        }
        else
        {
            int daysRequested = (int)(request.LeaveRequestDto.EndDate - request.LeaveRequestDto.StartDate).TotalDays;
            if (daysRequested > allocation.NumberOfDays)
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(
                    nameof(request.LeaveRequestDto.EndDate), "You do not have enough days for this request"));
            }
        }

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Request Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest.RequestingEmployeeId = userId;
            leaveRequest = await _unitOfWork.LeaveRequestRepository.Add(leaveRequest);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Request Created Successfully";
            response.Id = leaveRequest.Id;

            try
            {
                var emailAddress = "mostafa.vazini@yahoo.com";//_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

                var email = new Email
                {
                    To = emailAddress,
                    Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                    $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //// Log or handle error, but don't throw...
            }
        }

        return response;

    }
}