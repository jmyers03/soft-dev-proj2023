using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Linq;
using GoalsApp.Models;

namespace GoalsApp.Shared
{
    public class FirebaseService
    {
        private FirebaseClient _client;

        public FirebaseService(string firebaseUrl)
        {
            _client = new FirebaseClient(firebaseUrl);
        }

        //GET TASKS 
        public async Task<ObservableCollection<MyTask>> GetTasksByUserId()
        {
            var tasks = await _client
                .Child("Tasks")
                .OnceAsync<MyTask>();

            return new ObservableCollection<MyTask>(tasks.Select(t => t.Object).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //GET REMINDERS
        public async Task<ObservableCollection<Reminder>> GetReminderByUserId()
        {
            var reminders = await _client
                .Child("Reminders")
                .OnceAsync<Reminder>();

            return new ObservableCollection<Reminder>(reminders.Select(t => t.Object).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //GET GOALS 
        public async Task<ObservableCollection<MyTask>> GetGoalsByUserId()
        {
            var tasks = await _client
                .Child("Goals")
                .OnceAsync<MyTask>();

            return new ObservableCollection<MyTask>(tasks.Select(t => t.Object).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //GET USERS (could use for sharing Tasks or chatting with other users)
        public async Task<ObservableCollection<User>> GetUsers()
        {
            var tasks = await _client
                .Child("Users")
                .OnceAsync<User>();

            return new ObservableCollection<User>(tasks.Select(t => t.Object));
        }

        //input a username string and a password string and get a UserKey
        public async Task<string> GetUserKey(string username, string password)
        {
            var users = await _client
                .Child("Users")
                .OnceAsync<User>();

            var user = users.FirstOrDefault(u => u.Object.Username == username && u.Object.Password == password);
            return user?.Key;
        }

        //GET TASKS BY ID
        public async Task<ObservableCollection<MyTask>> GetTasksByUserIdWithKey()
        {
            var tasks = await _client
            .Child("Tasks")
            .OnceAsync<MyTask>();

            return new ObservableCollection<MyTask>(tasks.Select(t =>
            {
                var task = t.Object;
                task.Key = t.Key;
                return task;
            }).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //ADD TASK TO THE TABLE
        public async Task AddTask(MyTask task)
        {
            var tasks = await _client
                .Child("Tasks")
                .PostAsync(task);
        }

        //GET REMINDERS BY ID
        public async Task<ObservableCollection<Reminder>> GetReminderByUserIdWithKey()
        {
            var reminders = await _client
                .Child("Reminders")
                .OnceAsync<Reminder>();

            return new ObservableCollection<Reminder>(reminders.Select(t =>
            {
                var reminder = t.Object;
                reminder.Key = t.Key;
                return reminder;
            }).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //ADD REMINDERS TO THE TABLE
        public async Task AddReminders(Reminder reminder)
        {
            var reminders = await _client
                .Child("Reminders")
                .PostAsync(reminder);
        }

        //GET GOALS BY ID
        public async Task<ObservableCollection<Goal>> GetGoalsByUserIdWithKey()
        {
            var goals = await _client
                .Child("Goals")
                .OnceAsync<Goal>();

            return new ObservableCollection<Goal>(goals.Select(t =>
            {
                var goal = t.Object;
                goal.Key = t.Key;
                return goal;
            }).Where(t => t.UserKey == firebaseServiceUserKey));
        }

        //ADD GOAL TO THE TABLE
        public async Task AddGoal(Goal goal)
        {
            var goals = await _client
                .Child("Goals")
                .PostAsync(goal);
        }

        //ADD USER TO THE TABLE
        public async Task AddUser(User user)
        {
            var users = await _client
                .Child("Users")
                .PostAsync(user);
        }

        //SEE IF USERNAME IS UNQUIE 
        public async Task<bool> IsUsernameUnique(string username)
        {
            var users = await _client
                .Child("Users")
                .OnceAsync<User>();

            return !users.Any(user => user.Object.Username == username);
        }

        public string firebaseServiceUserKey;

    }
}
