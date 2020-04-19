using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace StorageProviders
{
    public static class UserExtensions
    {
        public static User ToUser(this TableResult result)
        {
            var userEntity = result.Result as UserTableEntity;

            return new User
            {
                Username = userEntity.Username,
            };
        }
    }
}
