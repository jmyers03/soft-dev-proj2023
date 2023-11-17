using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Model
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
    class Task 
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public Guid GoalId { get; set; }
        private string TaskDescription { get; set; }
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
