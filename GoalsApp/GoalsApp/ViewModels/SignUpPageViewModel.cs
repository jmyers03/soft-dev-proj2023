using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Shared;

namespace GoalsApp.ViewModels
{
    class SignUpPageViewModel
    {
        private FirebaseService firebaseService;
        public SignUpPageViewModel()
        {
            firebaseService = new FirebaseService("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");
        }

        public async Task SignUp(string username, string password)
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
