using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using GoalsApp;
using GoalsApp.ViewModels;

namespace GoalsApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        SignUpPageViewModel viewModel = new SignUpPageViewModel();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnForgotPasswordLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the PasswordRecoveryPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(PasswordRecovery));
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            Validation.IsVisible = await viewModel.LoginAttempt(username, password);

        }

        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private async void OnContinueWithoutAccountLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the Dashboard using Shell navigation
            // the backslashes navigate to the FlyoutItems defined in AppShell.xaml
            await Shell.Current.GoToAsync("//Dashboard");
        }
    }
}