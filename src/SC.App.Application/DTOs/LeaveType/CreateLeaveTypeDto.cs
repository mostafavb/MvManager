﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.App.Application.DTOs.LeaveType;
public class CreateLeaveTypeDto //: ILeaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
