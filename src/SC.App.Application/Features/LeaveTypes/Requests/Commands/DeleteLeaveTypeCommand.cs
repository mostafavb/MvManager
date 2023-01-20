using MediatR;

namespace SC.App.Application.Features.LeaveTypes.Requests.Commands;
public class DeleteLeaveTypeCommand : IRequest
{
    public int Id { get; set; }
}