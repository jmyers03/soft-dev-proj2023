using System;
using System.Collections.ObjectModel;
using GoalsApp.Models;
//*******UNCOMMENT THIS******////
//using Plugin.LocalNotification;
using Firebase.Database;
using Firebase.Database.Query;

namespace GoalsApp.ViewModels
{
    public class RemindersPageViewModel
    {
        private readonly FirebaseClient _firebase;


        // ObservableCollections use the CollectionChanged event to notify the UI when the collection
        // is refreshed, or items are added or removed

        // Creates upcoming and completed reminders
        public ObservableCollection<Reminder> UpcomingReminders { get; set; }
        public ObservableCollection<Reminder> CompletedReminders { get; set; }
        public ObservableCollection<MyTask> currentTasks { get; set; }

        // RemindersViewModel constructor
        public RemindersPageViewModel()
        {
            _firebase = new FirebaseClient("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");

            // Insert test data for upcoming reminders
            UpcomingReminders = new ObservableCollection<Reminder> { };

            // Insert test data for completed reminders
            CompletedReminders = new ObservableCollection<Reminder> { };

            currentTasks = new ObservableCollection<MyTask> { };
        }

        public async Task InitializeRemindersAsync()
        {
            var upcomingReminders = await _firebase.Child("Reminders").OnceAsync<Reminder>();
            UpcomingReminders = new ObservableCollection<Reminder>(upcomingReminders.Select(x => x.Object));
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
        public async Task GetUserTasks()
        {
            var firebaseClient = new FirebaseClient("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");

            //add only tasks with the userid 
            var allTasks = await firebaseClient
                .Child("Tasks")
                .OnceAsync<MyTask>();

            currentTasks.Clear();

            //get whether the task is completed or not
            foreach (var task in allTasks.Select(t => t.Object))
            {
                currentTasks.Add(task);
            }
        }

        public async Task GetUserReminders()
        {
            //add only tasks with the userid 
            var allReminders = await _firebase
                .Child("Reminders")
                .OnceAsync<Reminder>();

            UpcomingReminders.Clear();

            //get whether the task is completed or not
            foreach (var reminders in allReminders.Select(t => t.Object))
            {
                UpcomingReminders.Add(reminders);
            }
        }

        public async Task AddReminder(Reminder reminder)
        {
            // Add the reminder to Firebase
            await _firebase.Child("Reminders").PostAsync(reminder);

            UpcomingReminders.Add(reminder);
        }
    }
}