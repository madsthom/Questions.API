using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questions.API.Models;

namespace Questions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QaDbContext _context;

        public QuestionController(QaDbContext context)
        {
            _context = context;
        }

        // GET api/question
        [HttpGet("{id}", Name = "GetQuestion")]
        public ActionResult Get(int id)
        {
            var question = _context.Questions.Where(q => q.QuestionId == id).FirstOrDefault();

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // GET api/question/2
        [HttpGet]
        public ActionResult Get()
        {
            var questions = _context.Questions.OrderBy(q => q.QuestionId);

            return Ok(questions);
        }

        [HttpGet("{id}/answers")]
        public ActionResult GetAnswers(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);

            if (question == null)
            {
                return NotFound();
            }

            var answers = _context.Answers.Where(a => a.QuestionId == question.QuestionId);

            return Ok(answers);
        }

        // POST api/question
        [HttpPost]
        public ActionResult Post([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            _context.Questions.Add(question);
            _context.SaveChanges();

            return CreatedAtRoute("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var question = _context.Questions.Where(q => q.QuestionId == id).FirstOrDefault();

            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);

            return Ok(question);
        }
    }
}
