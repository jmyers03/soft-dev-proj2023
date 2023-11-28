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
        public string Id { get; set; }
        public string ReminderTitle { get; set; }
        
        //time the reminder should go off 
        public string SetDateAndTime { get; set; }
    }
}
