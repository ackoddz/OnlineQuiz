using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public string question { get; set; }
        public string possibleAnswers { get; set; }
        public string correctAnswer { get; set; }
    }
}