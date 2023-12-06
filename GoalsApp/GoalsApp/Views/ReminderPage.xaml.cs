using GoalsApp.ViewModels;
using GoalsApp.Models;
using Plugin.LocalNotification;


namespace GoalsApp.Views;

public partial class ReminderPage : ContentPage
{
    RemindersPageViewModel _viewModel = new RemindersPageViewModel();

    public ReminderPage()
    {
		InitializeComponent();

        InitializeViewModel();
    }

    private async void InitializeViewModel()
    {
        //sets the current Tasks list equal to the list 
        await _viewModel.GetUserReminders();
        await _viewModel.GetUserTasks();
        BindingContext = _viewModel;
    }

    private async void AddReminder_Clicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;
        DateTime? dateTime = new DateTime(
            DatePicker.Date.Year, DatePicker.Date.Month, DatePicker.Date.Day,
            TimePicker.Time.Hours, TimePicker.Time.Minutes, 0);
        var selectedTask = pickerTask.SelectedItem as MyTask;
        var taskNumber = selectedTask.Key;

        Reminder newReminder = new Reminder
        {
            Title = title,
            Description = description,
            AlertDateTime = dateTime,
            MyTaskKey = taskNumber
        };

        // Handle the Add Reminder action
        await _viewModel.AddReminder(newReminder);

        var request = new NotificationRequest
        {
            Title = newReminder.Title,
            Description = newReminder.Description,
            //NotificationId = newReminder.Key.GetHashCode(),
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = newReminder.AlertDateTime.Value,
                NotifyRepeatInterval = TimeSpan.FromMinutes(10) // Set the repeat interval as needed
            }
        };

        await LocalNotificationCenter.Current.Show(request);


        // Clear the text in the Entry fields
        TitleEntry.Text = "";
        DescriptionEntry.Text = "";
        DatePicker.Date = DateTime.Now.Date;
        TimePicker.Time = DateTime.Now.TimeOfDay;
        pickerTask.SelectedItem = null;
    }

    private void MarkAsCompleted_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Reminder reminder)
        {
            // Handle the Mark as Completed action
           _viewModel.MarkAsCompleted(reminder);
        }
    }

    private void DeleteReminder_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Reminder reminder)
        {
            // Handle the Delete Reminder action
            _viewModel.DeleteReminder(reminder);
        }
    }

    private void MarkAsUpcoming_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Reminder reminder)
        {
            // Handle the Mark as Upcoming action
            _viewModel.MarkAsUpcoming(reminder);
        }
    }
}