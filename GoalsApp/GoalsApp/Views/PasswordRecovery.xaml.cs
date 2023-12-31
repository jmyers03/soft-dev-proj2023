using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
namespace GoalsApp.Views; //new .NET 6.0 non-nested namespace declaration 

    public partial class PasswordRecovery : ContentPage
    {
    public PasswordRecovery()
    {
        InitializeComponent();
    }

    public ICommand SendRecoveryEmailCommand { get; }
    public ICommand CancelCommand { get; }

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
