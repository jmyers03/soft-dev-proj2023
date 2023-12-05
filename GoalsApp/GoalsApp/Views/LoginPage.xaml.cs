using GoalsApp.ViewModels;
using Microsoft.Maui.Controls;

namespace GoalsApp.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel viewModel = new LoginPageViewModel();
        //SQLdbContexts db;
        public LoginPage()
        {
            InitializeComponent();


            // Attach event handlers
            SignInButton.Clicked += OnSignInButtonClicked;
        }

        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            // Handle the Sign In button click here
            // You can access the username and password using Entry controls by their names
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            await viewModel.LoginAttempt(username, password);
        }

        private async void OnForgotPasswordLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the PasswordRecoveryPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(PasswordRecovery));
        }

        private async void OnContinueWithoutAccountLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the Dashboard using Shell navigation
            // the backslashes navigate to the FlyoutItems defined in AppShell.xaml
            await Shell.Current.GoToAsync("//Dashboard");
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the SignUpPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}