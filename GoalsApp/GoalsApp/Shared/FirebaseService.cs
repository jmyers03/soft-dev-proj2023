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

        //public async Task<ObservableCollection<Task>> GetTasksByUserId(int userId)
        //{
        //    var tasks = await _client
        //        .Child("tasks")
        //        .OnceAsync<MyTask>();

        //    return new ObservableCollection<Task>(tasks.Select(t => t.Object).Where(t => t.userId == userId));
        //}

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
