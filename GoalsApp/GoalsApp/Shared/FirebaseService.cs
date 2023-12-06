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

        public string firebaseServiceUserKey;

    }
}
