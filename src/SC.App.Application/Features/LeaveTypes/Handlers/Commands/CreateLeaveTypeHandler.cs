﻿using AutoMapper;
using MediatR;
using SC.App.Application.Contracts.Persistence;
using SC.App.Domain;

namespace SC.App.Application.Features.LeaveTypes.Handlers.Commands;
public class CreateLeaveTypeHandler //: IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    //public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    //{
    //    var response = new BaseCommandResponse();
    //    var validator = new CreateLeaveTypeDtoValidator();
    //    var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

    //    if (validationResult.IsValid == false)
    //    {
    //        response.Success = false;
    //        response.Message = "Creation Failed";
    //        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
    //    }
    //    else
    //    {
    //        var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

    //        leaveType = await _unitOfWork.LeaveTypeRepository.Add(leaveType);
    //        await _unitOfWork.Save();

    //        response.Success = true;
    //        response.Message = "Creation Successful";
    //        response.Id = leaveType.Id;
    //    }

    //    return response;
    //}
}
