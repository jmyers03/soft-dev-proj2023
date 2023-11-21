using Microsoft.Maui.Controls;

namespace GoalsApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            // Attach event handlers
            SignInButton.Clicked += OnSignInButtonClicked;
        }

        private void OnSignInButtonClicked(object sender, EventArgs e)
        {
            // Handle the Sign In button click here
            // You can access the username and password using Entry controls by their names
            string username = UsernameLabel.Text;
            string password = PasswordLabel.Text;

            /* Check if the provided credentials are valid by querying the database
            if (AppDatabase.AuthenticateUser(username, password))
            {
                // Authentication successful
                DisplayAlert("Success", "Authentication successful", "OK");

                // Here, you can navigate to the main app page or perform any other action
                // For example, you can use Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Authentication failed
                DisplayAlert("Error", "Authentication failed. Please check your credentials.", "OK");
            }
            */
        }

        private async void OnForgotPasswordLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the PasswordRecoveryPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(PasswordRecovery));
        }

        private async void OnTaskPageLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the PasswordRecoveryPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(TaskPage));
        }

        private async void OnCalendarPageLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the PasswordRecoveryPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(CalendarPage));
        }

        private async void OnRegisterLabelTapped(object sender, EventArgs e)
        {
            // Navigate to the RegistrationPage using Shell navigation
            await Shell.Current.GoToAsync(nameof(RegistrationPage));
        }
    }
}