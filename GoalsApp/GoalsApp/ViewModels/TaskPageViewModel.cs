using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using GoalsApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoalsApp.ViewModels
{
    public class TaskPageViewModel 
    {
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


            // Current tasks starts as empty and GetTasks is called in code behind 
            currentTasks = new ObservableCollection<MyTask> { };
            //Insert completed task test data here  - will come from database based on userId
            completedTasks = new ObservableCollection<MyTask> { };
            

            //Insert current Goal test data here - will come from database based on userId
            currentGoals = new ObservableCollection<Goal>
            {
                new Goal { Id = "1", Title = "Goal title id=1", Description = "This is a test goal description" },
                new Goal { Id = "2", Title = "Goal title id=2", Description = "This is a test goal description" },
                new Goal { Id = "3", Title = "Goal title id=3", Description = "This is a test goal description" }
            };
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

        public async Task AddTask()
        {
            var firebaseClient = new FirebaseClient("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");
            //define default task
            var defaultTask = new MyTask { Title = "Default Task", Description = "Default Description" };

            //add the default task
            var tasks = await firebaseClient
                .Child("Tasks")
                .PostAsync(defaultTask);

            //get all the tasks
            var allTasks = await firebaseClient
                .Child("Tasks")
                .OnceAsync<MyTask>();
            
            //clear current tasks 
            currentTasks.Clear();

            //set current tasks to all of the tasks in the database
            foreach (var task in allTasks.Select(t => t.Object))
            {
                currentTasks.Add(task);
            }
        }
    }
}
