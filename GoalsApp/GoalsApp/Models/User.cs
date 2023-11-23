using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp.Models
{
    public class User
    {
        //need a primarykey
        public Guid UserId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
    }
}
