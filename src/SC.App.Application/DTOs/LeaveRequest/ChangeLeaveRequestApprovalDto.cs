using SC.App.Application.DTOs.Common;

namespace SC.App.Application.DTOs.LeaveRequest;
public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool Approved { get; set; }
}