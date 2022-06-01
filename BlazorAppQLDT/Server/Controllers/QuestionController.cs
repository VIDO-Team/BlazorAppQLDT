using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppQLDT.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly DataContext _context;

        public QuestionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestions()
        {
            var questions = await _context.FQADetails
                .Include(q => q.FQA)
                .ToListAsync();
            return Ok(questions);
        }

        [HttpGet("answers")]
        public async Task<ActionResult<List<AnswersModel>>> GetAnswers()
        {
            var answers = await _context.FQA.ToListAsync();
            return Ok(answers);
        }

        [HttpGet("questionsbyfaqid/{id}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestionByFAQId(int id)
        {
            var question  = await _context.FQADetails
                .Where(q => q.FQAId == id)
                .ToListAsync();
            return Ok(question);
        }

         [HttpGet("answers/{id}")]
        public async Task<ActionResult<AnswersModel>> GetSingleAnswers(int id)
        {
            var answers = await _context.FQA
                .FirstOrDefaultAsync(q => q.Id == id);
            if(answers == null)
            {
                return NotFound("Sorry no answers here");
            }
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionModel>> GetSingleQuestion(int id)
        {
            var question = await _context.FQADetails
                .Include(q => q.FQA)
                .FirstOrDefaultAsync(q => q.Id == id);
            if(question == null)
            {
                return NotFound("Sorry no question here");
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionModel>> AddQuestion(QuestionModel question)
        {   
            question.FQAId = question.FQA.Id;
            await _context.FQADetails.AddAsync(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpPost("createfqa")]
        public async Task<ActionResult<QuestionModel>> CreateFQA(QuestionModel question)
        {   
            await _context.FQADetails.AddAsync(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionModel>> UpdateQuestion(QuestionModel question, int id)
        {
            var oldquestion = await _context.FQADetails
                .FirstOrDefaultAsync(q => q.Id == id);
            if (oldquestion == null)
            {
                return NotFound("Sorry no hero here");
            }
            oldquestion.Question = question.Question;
            oldquestion.QuestionType = question.QuestionType;
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var question = await _context.FQADetails
                .FirstOrDefaultAsync(q => q.Id == id);
            if (question == null)
            {
                return NotFound("Sorry no hero here");
            }
            _context.FQADetails.Remove(question);
            _context.SaveChanges();
            return Ok();
        }
    }
}
