namespace UserManagement.Abstractions.Models
{
    public interface IEntityResolver<TTableEntity,TEntity>
    {
        TTableEntity ToTableEntity(TEntity entity);
        TEntity ToEntity(TTableEntity tableEntity);
    }
}
