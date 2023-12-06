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
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace GoalsApp.Shared
{
    public class FirebaseService
    {
        private FirebaseClient _client;

        public FirebaseService(string firebaseUrl)
        {
            _client = new FirebaseClient(firebaseUrl);
        }

        //GET TASKS BY ID
        public async Task<ObservableCollection<MyTask>> GetTasksByUserId()
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
        public async Task<ObservableCollection<Reminder>> GetReminderByUserId()
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
        public async Task<ObservableCollection<Goal>> GetGoalsByUserId()
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

        //GET USERS BY ID (could use for sharing Tasks or chatting with other users)
        public async Task<ObservableCollection<User>> GetUsers()
        {
            var users = await _client
                .Child("Users")
                .OnceAsync<User>();

            return new ObservableCollection<User>(users.Select(t => t.Object));
        }

        //ADD USER TO THE TABLE
        public async Task AddUser(User user)
        {
            var users = await _client
                .Child("Users")
                .PostAsync(user);
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

        //SEE IF USERNAME IS UNQUIE 
        public async Task<bool> IsUsernameUnique(string username)
        {
            var user = await _client
                .Child("Users")
                .OrderByKey()
                .EqualTo(username)
                .OnceSingleAsync<User>();

            return user == null;
        }

        //set in the LoginPage
        public string firebaseServiceUserKey;

    }
}
