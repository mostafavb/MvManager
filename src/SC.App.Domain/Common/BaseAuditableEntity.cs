﻿namespace SC.App.Domain.Common;
public abstract class BaseAuditableEntity: BaseEntity
{    
    public DateTime DateCreated { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}
