using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalsApp.Models;

namespace GoalsApp.ViewModels
{
    class GoalPageViewModel
    {
        public ObservableCollection<MyTask> currentTasks { get; set; }
        public ObservableCollection<MyTask> currentGoals { get; set; }
        public ObservableCollection<Goal> completedGoals { get; set; }
    }
}
