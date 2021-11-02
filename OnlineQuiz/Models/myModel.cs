using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class myModel
    {
        public IEnumerable<OnlineQuiz.Models.Question> Questions { get; set; }
        public IEnumerable<OnlineQuiz.Models.Question> randomSample { get; set; }

    }
}