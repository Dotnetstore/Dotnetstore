namespace SharedKernel.Models;

public interface IBaseAuditableEntity
{
    Guid? LastUpdatedBy { get; }
    
    DateTime? LastUpdatedDate { get; }
    
    bool IsDeleted { get; }
    
    Guid? DeletedBy { get; }
    
    DateTime? DeletedDate { get; }
    
    bool IsSystem { get; }
    
    bool IsGdpr { get; }
}