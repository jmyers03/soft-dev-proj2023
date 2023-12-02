using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            string editedTitle;

            // Insert current Task test data here - will come from database based on userId
            currentTasks = new ObservableCollection<MyTask>
            {
                new MyTask { Id = "1", Title = "This task has no description (Id=1)"},
                new MyTask { Id = "2", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "3", Title = "This task has a description (Id=3)", Description = "Test Description"},
                new MyTask { Id = "4", Title = "This task has a description (Id=4)", Description = "Test Description"},
                new MyTask { Id = "5", Title = "This task has no description (Id=5)"},
                new MyTask { Id = "2", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "3", Title = "This task has a description (Id=3)", Description = "Test Description"},
                new MyTask { Id = "4", Title = "This task has a description (Id=4)", Description = "Test Description"},
                new MyTask { Id = "2", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "3", Title = "This task has a description (Id=3)", Description = "Test Description"},
                new MyTask { Id = "4", Title = "This task has a description (Id=4)", Description = "Test Description"},
                new MyTask { Id = "2", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "3", Title = "This task has a description (Id=3)", Description = "Test Description"}
            };

            //Insert completed task test data here  - will come from database based on userId
            completedTasks = new ObservableCollection<MyTask>
            {
                new MyTask { Id = "1", Title = "This task should show as completed (Id=1)", Completed=true },
                new MyTask { Id = "1", Title = "This task should show as completed (Id=2)", Completed=true }
            };

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
    }
}
