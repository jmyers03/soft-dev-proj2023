using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Shared;
using GoalsApp.Models;

namespace GoalsApp.ViewModels
{
    class SignUpPageViewModel
    {
        private FirebaseService firebaseService;
        public SignUpPageViewModel()
        {
            firebaseService = new FirebaseService("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");
        }

        public async Task<string> SignUp(string username, string password)
        {
            string phrase = "";

            if (await firebaseService.IsUsernameUnique(username))
            {
                User newUser = new User { Username = username, Password = password };

                await firebaseService.AddUser(newUser);
                phrase = "Account Created!";
                return phrase;
            }
            else
            {
                phrase = "Username taken!";
                return phrase;
            }
        }
    }
}