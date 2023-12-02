using System;
using System.Collections.ObjectModel;
using GoalsApp.Models;

namespace GoalsApp.ViewModels
{
    public class RemindersViewModel
    {
        // ObservableCollections use the CollectionChanged event to notify the UI when the collection
        // is refreshed, or items are added or removed

        // Creates upcoming and completed reminders
        public ObservableCollection<Reminder> UpcomingReminders { get; set; }
        public ObservableCollection<Reminder> CompletedReminders { get; set; }

        // RemindersViewModel constructor
        public RemindersViewModel()
        {
            // Insert test data for upcoming reminders
            UpcomingReminders = new ObservableCollection<Reminder>
            {
                new Reminder { Id = 1, Title = "Upcoming Reminder 1", DateTime = DateTime.Now.AddHours(1) },
                new Reminder { Id = 2, Title = "Upcoming Reminder 2", DateTime = DateTime.Now.AddHours(2) },
                // Add more test data as needed
            };

            // Insert test data for completed reminders
            CompletedReminders = new ObservableCollection<Reminder>
            {
                new Reminder { Id = 3, Title = "Completed Reminder 1", DateTime = DateTime.Now.AddHours(-1), Completed = true },
                new Reminder { Id = 4, Title = "Completed Reminder 2", DateTime = DateTime.Now.AddHours(-2), Completed = true },
                // Add more test data as needed
            };
        }

        public void MarkAsCompleted(Reminder reminder)
        {
            UpcomingReminders.Remove(reminder);
            reminder.Completed = true;
            CompletedReminders.Insert(0, reminder);
        }

        public void MarkAsUpcoming(Reminder reminder)
        {
            CompletedReminders.Remove(reminder);
            reminder.Completed = false;
            UpcomingReminders.Insert(0, reminder);
        }

        public void AddReminder(Reminder reminder)
        {
            // Add logic to schedule the reminder (similar to MoveToCompleted in TaskPageViewModel)
            // You can use plugins like Xamarin.Essentials for scheduling notifications
            // Make sure to handle platform-specific details and permissions
            UpcomingReminders.Add(reminder);
        }

        public void DeleteReminder(Reminder reminder)
        {
            // Add logic to cancel the scheduled reminder
            // You may need to use platform-specific code or third-party libraries
            UpcomingReminders.Remove(reminder);
            CompletedReminders.Remove(reminder);
        }
    }
}