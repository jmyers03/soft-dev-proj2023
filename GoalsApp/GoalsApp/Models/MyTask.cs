using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Models
{
    //"Task" is already a C# keyword, so made the class name "MyTask" 
    public class MyTask
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Gets the current date and sets it to the current date if there is not one
        public string CompletionDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");
        public string CompletionTime { get; set; }
        public string GoalId { get; set; }
        //how long it will take to complete the task 
        public string TimeToComplete { get; set; }
        public bool Completed { get; set; } = false;
        public string UserId { get; set; }
    }
}
