namespace Repository.Interfaces
{
    public interface IEntityAuditHelper
    {
        void SetUpdatedAuditFields<T>(T entity, Guid? updatedByUserId) where T : class;
    }
}
