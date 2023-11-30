using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoalsApp.Models
{
    public class Goal
    {
        public string Id { get; set; }
        public string TaskTitle { get; set; }
        // ? signifies a nullable field, making it optional to create the object 
        public string TaskId { get; set; }
        public string Description { get; set; } = null;
        // Gets the current date and sets it to the current date if there is not one
        public string CompletionDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");
        public string CompletionTime { get; set; }
        public string TimeToComplete { get; set; }
        public List<MyTask> AssociatedTasks { get; set; }
    }
}
