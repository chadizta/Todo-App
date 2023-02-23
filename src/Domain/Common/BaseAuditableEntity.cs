namespace Todo_App.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity, IBaseAuditableEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}

public interface IBaseAuditableEntity
{ 
    int Id { get; set; }

    DateTime Created { get; set; }

    string? CreatedBy { get; set; }

    DateTime? LastModified { get; set; }

    string? LastModifiedBy { get; set; }

    DateTime? Deleted { get; set; }

    string? DeletedBy { get; set; }

    bool IsDeleted { get; set; } 
}