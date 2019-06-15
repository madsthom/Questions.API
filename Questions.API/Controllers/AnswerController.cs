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
    public class AnswerController : ControllerBase
    {
        private readonly QaDbContext _context;

        public AnswerController(QaDbContext context)
        {
            _context = context;
        }

        // GET api/answer
        [HttpGet("{id}", Name = "GetAnswer")]
        public ActionResult Get(int id)
        {
            Answer answer = _context.Answers.Where(a => a.AnswerId == id).FirstOrDefault();

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // GET api/answer/2
        [HttpGet]
        public ActionResult Get()
        {
            var answers = _context.Answers.OrderBy(q => q.AnswerId);

            return Ok(answers);
        }

        // POST api/question
        [HttpPost]
        public ActionResult Post([FromBody] Answer answer)
        {
            if (answer == null)
            {
                return BadRequest();
            }

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return CreatedAtRoute("GetAnswer", new { id = answer.AnswerId }, answer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var answer = _context.Answers.Where(q => q.AnswerId == id).FirstOrDefault();

            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);

            return Ok(answer);
        }
    }
}
