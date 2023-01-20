using SC.App.Application.DTOs.Common;
using SC.App.Application.DTOs.LeaveType;

namespace SC.App.Application.DTOs.LeaveAllocation;
public class LeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    //public Employee Employee { get; set; }
    public string EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}