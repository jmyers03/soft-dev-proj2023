using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using GoalsApp;

namespace YourAppName
{
    public partial class RegistrationPage : ContentPage
    {
        public ICommand RegisterCommand { get; }
        public ICommand SignInCommand { get; }

        public RegistrationPage()
        {

            RegisterCommand = new Command(async () => await Register());
            SignInCommand = new Command(async () => await SignIn());

            BindingContext = this;
        }

        private async Task Register()
        {
            // Handle registration logic here
            // You can collect user input from the Entry fields and process the registration
        }

        private async Task SignIn()
        {
            // Navigate to the Login Page
            await Navigation.PushAsync(new LoginPage());
        }
    }
}