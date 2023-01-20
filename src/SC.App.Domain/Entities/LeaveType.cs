using SC.App.Domain.Common;

namespace SC.App.Domain.Entities;
public class LeaveType : BaseAuditableEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}