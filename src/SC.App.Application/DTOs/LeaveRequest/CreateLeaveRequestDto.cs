using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.DTOs.LeaveRequest;
public class CreateLeaveRequestDto : ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComments { get; set; }=string.Empty;
}
