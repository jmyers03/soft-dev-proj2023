using System;
using System.Collections.ObjectModel;
using GoalsApp.Models;
using Plugin.LocalNotification;

namespace GoalsApp.ViewModels
{
    public class RemindersPageViewModel
    {
        // ObservableCollections use the CollectionChanged event to notify the UI when the collection
        // is refreshed, or items are added or removed

        // Creates upcoming and completed reminders
        public ObservableCollection<Reminder> UpcomingReminders { get; set; }
        public ObservableCollection<Reminder> CompletedReminders { get; set; }
        public ObservableCollection<MyTask> currentTasks { get; set; }

        // RemindersViewModel constructor
        public RemindersPageViewModel()
        {
            // Insert test data for upcoming reminders
            UpcomingReminders = new ObservableCollection<Reminder>
            {
                new Reminder { Id = "1", Title = "Upcoming Reminder 1", DateTime = DateTime.Now.AddHours(1) },
                new Reminder { Id = "2", Title = "Upcoming Reminder 2", DateTime = DateTime.Now.AddHours(2) },
                // Add more test data as needed
            };

            // Insert test data for completed reminders
            CompletedReminders = new ObservableCollection<Reminder>
            {
                new Reminder { Id = "3", Title = "Completed Reminder 1", DateTime = DateTime.Now.AddHours(-1), Completed = true },
                new Reminder { Id = "4", Title = "Completed Reminder 2", DateTime = DateTime.Now.AddHours(-2), Completed = true },
                // Add more test data as needed
            };

            currentTasks = new ObservableCollection<MyTask>
            {
                new MyTask { Id = "5", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "6", Title = "This task has a description (Id=2)", Description = "Test Description"},
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

        public void DeleteReminder(Reminder reminder)
        {
            UpcomingReminders.Remove(reminder);
            CompletedReminders.Remove(reminder);
        }

        public string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

        public void AddReminder(Reminder reminder)
        {
            if (reminder.DateTime.HasValue && reminder.DateTime > DateTime.Now)
            {
                // Add the reminder to the upcoming list and schedule notification
                UpcomingReminders.Add(reminder);
            }
        }
    }
}