using System;
namespace Questions.API.DtoModels
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
    }
}
