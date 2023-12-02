using GoalsApp.ViewModels;
using GoalsApp.Models;

namespace GoalsApp.Views;

public partial class ReminderPage : ContentPage
{
	public ReminderPage()
    {
		InitializeComponent();

		BindingContext = new RemindersViewModel();
	}
}