namespace SharedKernel.Models;

public abstract class BaseAuditableEntity : IBaseAuditableEntity
{
    public Guid? CreatedBy { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid? LastUpdatedBy { get; set; }
    
    public DateTime? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    
    public Guid? DeletedBy { get; set; }
    
    public DateTime? DeletedDate { get; set; }
    
    public bool IsSystem { get; set; }
    
    public bool IsGdpr { get; set; }
}