using GoalsApp.ViewModels;
using GoalsApp.Models;
using Plugin.LocalNotification;


namespace GoalsApp.Views;

public partial class ReminderPage : ContentPage
{
    private RemindersPageViewModel _viewModel;

    public ReminderPage()
    {
		InitializeComponent();
        _viewModel = new RemindersPageViewModel();
        BindingContext = _viewModel;
    }

    private void AddReminder_Clicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;
        DateTime? dateTime = new DateTime(
            DatePicker.Date.Year, DatePicker.Date.Month, DatePicker.Date.Day,
            TimePicker.Time.Hours, TimePicker.Time.Minutes, 0);
        var selectedTask = pickerTask.SelectedItem as MyTask;
        var taskNumber = selectedTask.Id;

        Reminder newReminder = new Reminder
        {
            Id = _viewModel.GenerateUniqueId(),
            Title = title,
            Description = description,
            DateTime = dateTime,
            MyTaskId = taskNumber
        };

        // Handle the Add Reminder action
        _viewModel.AddReminder(newReminder);

        var request = new NotificationRequest
        {
            Title = newReminder.Title,
            Description = newReminder.Description,
            NotificationId = newReminder.Id.GetHashCode(),
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = newReminder.DateTime.Value,
                NotifyRepeatInterval = TimeSpan.FromMinutes(10) // Set the repeat interval as needed
            }
        };

        LocalNotificationCenter.Current.Show(request);

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

    
    private void TaskPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedTask = (MyTask)picker.SelectedItem;
    }
}