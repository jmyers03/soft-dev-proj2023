using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoalsApp.Models
{
    public class Goal
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = null;
        // Gets the current date and sets it to the current date if there is not one
        public DateTime CompletionDateTime { get; set; } 
        public string TaskKey { get; set; }
        public string UserKey { get; set; }
    }
}