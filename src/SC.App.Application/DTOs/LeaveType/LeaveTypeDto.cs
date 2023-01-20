using SC.App.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.App.Application.DTOs.LeaveType;
public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}