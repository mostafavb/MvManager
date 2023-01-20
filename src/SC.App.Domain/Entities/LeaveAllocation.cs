using SC.App.Domain.Common;

namespace SC.App.Domain.Entities;
public class LeaveAllocation : BaseAuditableEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; }
}