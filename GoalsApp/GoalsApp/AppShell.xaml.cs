namespace GoalsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PasswordRecovery), typeof(PasswordRecovery));
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
	}
}
