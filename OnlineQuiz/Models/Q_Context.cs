using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models 
{
    public class Q_Context : DbContext
    {
        public Q_Context()
            : base("name=Q_Context")
        { }

        public DbSet<Question> Questions { get; set; }
    }
}