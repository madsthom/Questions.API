using System;
namespace Questions.API.Models
{
    public class Answer
    {
        public Answer(string answerText)
        {
            AnswerText = answerText;
        }

        public Answer()
        {

        }

        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
