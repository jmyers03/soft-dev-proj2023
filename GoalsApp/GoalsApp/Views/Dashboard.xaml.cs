namespace GoalsApp.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
        InitializeComponent();
    }

    private void ToGoalsButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(GoalPage));
    }

    private void ToTasksButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(TaskPage));
    }

    private void ToRemindersButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ReminderPage));
    }

    private void ToCalendarButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CalendarPage));
    }
}