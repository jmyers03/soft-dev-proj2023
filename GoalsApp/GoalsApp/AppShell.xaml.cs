using GoalsApp.Views;

namespace GoalsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//ADD NEW PAGE ROUTES HERE
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(Dashboard), typeof(Dashboard));
        Routing.RegisterRoute(nameof(PasswordRecovery), typeof(PasswordRecovery));
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
		Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
		Routing.RegisterRoute(nameof(UIExperiments), typeof(UIExperiments));
	}
}
