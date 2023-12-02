using Microsoft.Maui.Controls;
using SQLite;
using System.Data;
using System.Data.SqlClient;


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

        SQLiteConnection conn = new SQLiteConnection(@"Data Source connection");

        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            // Handle the Sign In button click here
            // You can access the username and password using Entry controls by their names
            string username = UsernameLabel.Text;
            string password = PasswordLabel.Text;


            try
            {
                string query = "SELECT * FROM login_credentials WHERE username = '" + UsernameLabel.Text + "' AND password='" + PasswordLabel.Text + "'";
                 sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count > 0)
                {
                    username = UsernameLabel.Text;
                    password = PasswordLabel.Text;

                    //page that needed to be load next
                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide(); 
                }


            }
            catch
            {
                await DisplayAlert("Slow down there tiger!", "Looks like your username or password is not correct. Please re-enter credentials", "OK");
                UsernameLabel.ClearValue();
                PasswordLabel.ClearValue();

                //to focus username
                UsernameLabel.Focus();
            }
            finally
            {
                conn.Close();
            }

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