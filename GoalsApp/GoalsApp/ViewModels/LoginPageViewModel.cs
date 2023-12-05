using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Shared;
using GoalsApp.Views;

namespace GoalsApp.ViewModels
{
    class LoginPageViewModel
    {
        private FirebaseService firebaseService;
        public LoginPageViewModel()
        {
            firebaseService = new FirebaseService("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");
        }

        public async Task LoginAttempt(string username, string password)
        {
            string userKey = await firebaseService.GetUserKey(username, password);
            
            //variable that can be grabbed by anyone that implements the FirebaseService class 
            firebaseService.firebaseServiceUserKey = userKey;

            if (firebaseService.firebaseServiceUserKey != null)
            {
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                Console.WriteLine("Invalid entry");
            }
        }
    }
}
