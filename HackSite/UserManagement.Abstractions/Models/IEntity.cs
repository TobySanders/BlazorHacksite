namespace UserManagement.Abstractions.Models
{
    public interface IEntity<TKey>
    {
        TKey Key { get; }
    }
}
