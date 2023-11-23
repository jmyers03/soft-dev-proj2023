using GoalsApp.ViewModels;

namespace GoalsApp.Views;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();

        //Set the binding context to the TaskPageViewModel 
        BindingContext = new TaskPageViewModel();
    }
}