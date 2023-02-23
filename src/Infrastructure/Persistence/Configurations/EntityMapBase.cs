using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo_App.Domain.Common;

namespace Todo_App.Infrastructure.Persistence.Configurations;
public abstract class EntityMapBase<TEntity> : IEntityMap<TEntity> where TEntity : class, IBaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}

public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{

}