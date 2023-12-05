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
        //internal int Id;

        //need a primarykey
        public string Key { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
    }
}
