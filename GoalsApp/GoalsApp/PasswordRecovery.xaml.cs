using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace GoalsApp
{
    public partial class PasswordRecoveryDialog : ContentPage
    {
        public ICommand SendRecoveryEmailCommand { get; }
        public ICommand CancelCommand { get; }

        public PasswordRecoveryDialog()
        {
            SendRecoveryEmailCommand = new Command(async () => await SendRecoveryEmail());
            CancelCommand = new Command(async () => await ClosePopup());
            BindingContext = this;
        }

        private async Task SendRecoveryEmail()
        {
            var message = new EmailMessage
            {
                Subject = "My Email Subject",
                Body = "Email body goes here",
                To = new List<string> { "recipient@example.com" }
            };

            try
            {
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Handle other exceptions or errors
            }
        }

        private async Task ClosePopup()
        {
            await Navigation.PopModalAsync();
        }
    }
}