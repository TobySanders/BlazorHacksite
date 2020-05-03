namespace UserManagement.Abstractions.Models
{
    public interface IEntityResolver<TSourceType,TTargetType>
    {
        TSourceType ToSourceType(TTargetType entity);
        TTargetType ToTargetType(TSourceType tableEntity);
    }
}
