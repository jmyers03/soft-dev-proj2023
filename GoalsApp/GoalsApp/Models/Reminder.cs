using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Models
{
    public class Reminder
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Completed { get; set; }
        public string MyTaskId { get; set; } // Unique identifier for the associated task

    }
}
