using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GoalsApp.Model
{
    public class UserClass
    {
        //need a primarykey
        public Guid UserId { get; set; }
        public int Id { get; internal set; }
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
    class Tasks
    {
        public Guid TasksId { get; set; }
        public string TasksTitle { get; set; }
        public Guid GoalId { get; set; }
        private string TasksDescription { get; set; }
    }

    public class Affirmation
    {
        [PrimaryKey, AutoIncrement]
        public Guid affirmationId { get; set; }
        public string affirmationTitle { get; set; }
        public string affirmationContents { get; set; }
        public Guid GoalId { get; set; }
    }

    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        public Guid remiderId { get; set; }
        public string reminderTitle { get; set; }
        public DateTime DateAndTime { get; set; }
    }

}
