using Repository.Interfaces;

namespace Repository.Utils
{
    public class EntityAuditHelper : IEntityAuditHelper
    {
        public void SetUpdatedAuditFields<T>(T entity, Guid? updatedByUserId) where T : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var updatedAtProperty = typeof(T).GetProperty("UpdatedAt");
            var updatedByProperty = typeof(T).GetProperty("UpdatedBy");

            if (updatedAtProperty != null && updatedAtProperty.PropertyType == typeof(DateTime?))
            {
                updatedAtProperty.SetValue(entity, DateTime.UtcNow);
            }

            if (updatedByProperty != null && updatedByProperty.PropertyType == typeof(Guid?))
            {
                updatedByProperty.SetValue(entity, updatedByUserId);
            }
        }
    }
}
