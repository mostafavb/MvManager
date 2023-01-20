using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.DTOs.LeaveAllocation;
public class CreateLeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = new();
    public string EmployeeId { get; set; } = string.Empty;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
