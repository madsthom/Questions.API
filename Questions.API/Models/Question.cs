using System;
using System.Collections.Generic;

namespace Questions.API.Models
{
    public class Question
    {
        public Question(string questionText)
        {
            QuestionText = questionText;
            Answers = new List<Answer>();
        }

        public Question()
        {
            Answers = new List<Answer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
