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
        public ObservableCollection<MyTask> Tasks { get; set; }

        //TaskViewModel constructor 
        public TaskPageViewModel()
        {
            DateTime TodayDate = DateTime.Now;
            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask { Id = "1", Title = "This task has no description (Id=1)"},
                new MyTask { Id = "2", Title = "This task has a description (Id=2)", Description = "Test Description"},
                new MyTask { Id = "3", Title = "This task has a description (Id=3)", Description = "Test Description"},
                new MyTask { Id = "4", Title = "This task has a description (Id=4)", Description = "Test Description"},
                new MyTask { Id = "5", Title = "This task has no description (Id=5)"}
            };
        }

    }
}
