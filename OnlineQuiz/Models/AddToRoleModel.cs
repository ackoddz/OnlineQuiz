using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class AddToRoleModel
    {
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string SelectRole { get; set; }

        public AddToRoleModel()
        {
            Roles = new List<string>();
        }
    }
}