using HackSite.Shared;
using UserManagement.Abstractions.Models;

namespace HackSite.Server.Mappers
{
    //Made this class as a quick fix before an actual way to build responses has been implemented

    public static class Mappers
    {
        public static UserView Map(this User user)
        {
            return new UserView
            {
                username = user.Username
            };
        }
    }
}
