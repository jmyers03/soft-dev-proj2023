using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Database;
using Firebase.Database.Query;
using GoalsApp.Models;
using GoalsApp.Shared;
using GoalsApp.Views;

namespace GoalsApp.ViewModels
{
    public class TaskPageViewModel 
    {
        private FirebaseService _firebaseSerivce;
        //OberservableCollections use the CollectionChanged event to notiify the UI when the collection
        //is refreshed, or items are added or removed 
        //creates completed and current tasks (pull in entries for each list from the database by using the Completed property)
        public ObservableCollection<MyTask> currentTasks { get; set; }
        public ObservableCollection<MyTask> completedTasks { get; set; }
        public ObservableCollection<Goal> currentGoals { get; set; }

        //TaskViewModel constructor 
        public TaskPageViewModel()
        {
            DateTime TodayDate = DateTime.Now;

            _firebaseSerivce = new FirebaseService("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");

            // Current tasks starts as empty and GetTasks is called in code behind 
            currentTasks = new ObservableCollection<MyTask> { };

            //Insert completed task test data here  - will come from database based on userId
            completedTasks = new ObservableCollection<MyTask> { };
            

            //Insert current Goal test data here - will come from database based on userId
            currentGoals = new ObservableCollection<Goal> { };

        }
        public void MoveToCompleted(MyTask task)
        {
            currentTasks.Remove(task);
            completedTasks.Insert(0,task);
        }

        public void MoveToCurrent(MyTask task)
        {
            completedTasks.Remove(task);
            currentTasks.Insert(0,task);
        }

        public void ModifyCompletedTask(MyTask task, Goal goal)
        {

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

        public void AddDefaultTask(MyTask task)
        {

            //define default task
            task = new MyTask { Title = "Default Task", Description = "Default Description" };

            // Add the default task to the currentTasks collection
            currentTasks.Insert(0, task);

        }

        public async Task SaveTask(MyTask task)
        {
            
            var firebaseClient = new FirebaseClient("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");

            currentTasks.Clear();

            //add the default task
            var tasks = await firebaseClient
                .Child("Tasks")
                .PostAsync(task);

            //get all the tasks
            var allTasks = await firebaseClient
                .Child("Tasks")
                .OnceAsync<MyTask>();

            foreach (var addtask in allTasks.Select(t => t.Object))
            {
                currentTasks.Add(addtask);
            }
            
            MessagingCenter.Send(this, "TaskAdded");
        }
    }
}
