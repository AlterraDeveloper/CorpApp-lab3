using System;
using System.Linq;
using System.Web.Security;

namespace CorpApp_lab3.Models
{
    public class SimpleRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var result = false;

            using (var dbContext = new AudioPlayerDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.FullName == username);

                if (user != null)
                {
                    if (user.Role.Name == roleName) result = true;
                }
            }
            return result;
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}