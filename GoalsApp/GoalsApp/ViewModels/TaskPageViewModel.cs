using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Models;

namespace GoalsApp.ViewModels
{
    public class TaskPageViewModel 
    {
        //OberservableCollections use the CollectionChanged event to notiify the UI when the collection
        //is refreshed, or items are added or removed 

        //creates completed and current tasks (pull in entries for each list from the database by using the Completed property)
        public ObservableCollection<MyTask> currentTasks { get; set; }
        public ObservableCollection<MyTask> completedTasks { get; set; }

        //TaskViewModel constructor 
        public TaskPageViewModel()
        {
            DateTime TodayDate = DateTime.Now;
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

            //Insert completed task test data here
            completedTasks = new ObservableCollection<MyTask>
            {
                new MyTask { Id = "1", Title = "This task should show as completed (Id=1)", Completed=true },
                new MyTask { Id = "1", Title = "This task should show as completed (Id=2)", Completed=true }
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
    }
}
