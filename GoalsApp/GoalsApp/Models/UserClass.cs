using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Models
{
    class UserClass
    {
        //need a primarykey
        public Guid UserId { get; set; }
        private string UserName { get; set; }
        private string UserPassword { get; set; }
    }

    class UserSettings
    {
        //need a foreign key
        public Guid UserId { get; set; }
    }

    public class Goal
    {
        public Guid GoalId { get; set; }
        public string GoalTitle { get; set; }
        private string GoalDescription { get; set; }
    }
    class MyTask 
    {
        // the question mark makes the property nullable
        // this will basically make those fields optinal 
        // so for a task, all you need is a TaskId, and a Task Title
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public Guid? GoalId { get; set; }
        private string? TaskDescription { get; set; }
        private string? CompletionDate { get; set; }
        private string? CompletionTime { get; set; }
        private string? TimeToComplete { get; set; }
    }
    class Affirmation
    {
        public Guid affirmationId { get; set; }
        private string affirmationTitle { get; set; }
        private string affirmationContents { get; set; }
        public Guid GoalId { get; set; }
    }
    class Reminder
    {
      public Guid remiderId { get; set; }
      public  string reminderTitle { get; set;  }
      public DateAndTime DateAndTime { get; set; }  
    }
}
