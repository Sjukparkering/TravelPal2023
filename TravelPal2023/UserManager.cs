using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    
    
    public static class UserManager
    {
        public static List<IUser> users { get; set; } = new()
        {
            new Admin("admin", "password", Country.Sweden),

            new User("user", "password", Country.Sweden)
            {
                Travels = new List<Travel>()
                {
                    new WorkTrip("Speak with John", "Dublin", Country.Ireland, 2),
                    new Vacation(true, "Phuket", Country.Thailand, 3)
                }
            }
            
                
            



        };

        public static IUser SignedInUser { get; set; } 

        public static void AdminRemoveTravel(Travel travelToRemove)
        {
            foreach(var user in UserManager.users)
            {
                if(user is User)
                {

                    for (int i = 0; i < ((User)user).Travels.Count(); i++)
                    {
                        if (((User)user).Travels[i] == travelToRemove)
                        {
                            ((User)user).Travels.Remove(travelToRemove);
                            break;
                        }
                    }
                }
            }


        }


        public static List<Travel> GetAllUserTravels()
        {
            List<Travel> allUserTravels = new();

            foreach(var user in users)
            {
                if(user is User)
                {
                    allUserTravels.AddRange(((User)user).Travels);
                }
            }

            return allUserTravels;
        }

        public static bool AddUser(IUser user)
        {
            if(ValidateUsername(user.Username))
            {
                users.Add(user);

                return true;
            }
            else
            {
                return false;
            }
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

                    
                    foreach (var user in users)
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
            foreach(var user in users)
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
