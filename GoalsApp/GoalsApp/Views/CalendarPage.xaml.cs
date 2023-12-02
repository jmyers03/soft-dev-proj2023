using GoalsApp.ViewModels;

namespace GoalsApp.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
		BindingContext = new CalendarPageViewModel();
	}
}