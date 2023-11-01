using Microsoft.Maui.Controls;

namespace GoalsApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            // Attach event handlers
            SignInButton.Clicked += OnSignInButtonClicked;
            ForgotPasswordLabel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OnForgotPasswordLabelTapped) });
            RegisterLabel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OnRegisterLabelTapped) });
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

        private void OnForgotPasswordLabelTapped()
        {
            // Navigate to the PasswordRecoveryPage
            Navigation.PushAsync(new PasswordRecovery());
        }

        private void OnRegisterLabelTapped()
        {
            // Handle the Register label click here
            // You can navigate to the registration page or show a registration form
        }
    }
}