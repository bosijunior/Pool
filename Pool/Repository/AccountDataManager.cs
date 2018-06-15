using Pool.DataAccess;
using Pool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pool.Repository
{
    public static class AccountDataManager
    {
        public static bool AreCredentialsCorrect(string username, string password)
        {
            using (DatabaseModel model = new DatabaseModel())
            {
                var user = model.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                return user != null;
            }
        }

        public static User GetUser(string username)
        {
            using (DatabaseModel model = new DatabaseModel())
            {
                var user = model.Users.FirstOrDefault(x => x.Username == username);

                return new User
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    RoleID = user.RoleID,
                };
            }
        }

        public static string GetRolesForUser(string username)
        {
            using (DatabaseModel model = new DatabaseModel())
            {
                var user = model.Users.FirstOrDefault(x => x.Username == username);

                return user == null ? string.Empty : user.RoleID.ToString();
            }
        }
    }
}