using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Models
{
    internal class UserSettings
    {
        public Guid UserId { get; set; }
        //true or false for having dark mode enabled 
        public bool DarkModeFlag { get; set; }
    }
}
