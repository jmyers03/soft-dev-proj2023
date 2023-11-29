using GoalsApp.ViewModels;

namespace GoalsApp.Views;

public partial class GoalPage : ContentPage
{
	public GoalPage()
	{
		InitializeComponent();

        //Set the binding context to the TaskPageViewModel 
        BindingContext = new GoalPageViewModel();
    }
}