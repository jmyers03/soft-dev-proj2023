using Firebase.Database;
using GoalsApp.Models;
using Plugin.Maui.Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Shared;


namespace GoalsApp.ViewModels
{
    public class CalendarPageViewModel
    {
        public EventCollection Events { get; set; }
        private FirebaseService firebaseService;
        

        public CalendarPageViewModel()
        {
            firebaseService = new FirebaseService("https://goalsapp-9c3f5-default-rtdb.firebaseio.com/");
            Events = new EventCollection();

            LoadTasksAndGoals();

            MessagingCenter.Subscribe<TaskPageViewModel>(this, "TaskAdded", (sender) =>
            {
                LoadTasksAndGoals();
            });
        }

        private async void LoadTasksAndGoals()
        {
            var tasks = await firebaseService.GetTasksByUserId();
            var goals = await firebaseService.GetGoalsByUserId();

            MapTasksToEvents(tasks);
            MapGoalsToEvents(goals);
        }

        private void MapTasksToEvents(IEnumerable<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                var eventDate = task.CompletionDateTime;
                if (!Events.ContainsKey(eventDate))
                {
                    Events[eventDate] = new List<EventModel>();
                }

                var eventList = Events[eventDate] as List<EventModel>;
                eventList?.Add(new EventModel { Title = task.Title, Description = task.Description, CompletionDateTime = task.CompletionDateTime });
            }
        }

        private void MapGoalsToEvents(IEnumerable<MyTask> goals)
        {
            foreach (var goal in goals)
            {
                var eventDate = goal.CompletionDateTime;
                if (!Events.ContainsKey(eventDate))
                {
                    Events[eventDate] = new List<EventModel>();
                }

                var eventList = Events[eventDate] as List<EventModel>;
                eventList?.Add(new EventModel { Title = goal.Title, Description = goal.Description , CompletionDateTime = goal.CompletionDateTime});
            }
        }

        internal class EventModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? CompletionDateTime { get; set; }

        }
    }
}