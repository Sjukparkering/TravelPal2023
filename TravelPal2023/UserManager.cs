using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    
    
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {
            new Admin("Admin", "Password", Country.Somalia),

            new User("User", "Password", Country.Somalia)

        };

        public static IUser SignedInUser { get; set; } 

        public static bool AddUser(IUser user)
        {
            if(ValidateUsername(user.Username))
            {
                Users.Add(user);

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RemoveUser(IUser user)
        {

        }

        public static bool UpdateUsername(IUser user, string newUsername)
        {
            throw new NotImplementedException();
        }

        private static bool ValidateUsername(string username)
        {                
                    bool isValid = false;

                    
                    if (!string.IsNullOrEmpty(username))
                    {
                        isValid = true;
                    }

                    
                    foreach (var user in Users)
                    {
                        if (user.Username == username)
                        {
                            isValid = false;
                            break;
                        }

                    }

                    return isValid;
                
        }

        public static bool SignInUser(string username, string password)
        {
            foreach(var user in Users)
            {
                if(user.Username == username && user.Password == password)
                {
                    SignedInUser = user;

                    return true;
                }
            }

            return false;
        }
    }

}
