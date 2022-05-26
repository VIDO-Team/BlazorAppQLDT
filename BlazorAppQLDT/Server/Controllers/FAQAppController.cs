using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppQLDT.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FAQAppController : ControllerBase
    {
        private readonly DataContext _context;

        public FAQAppController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<FAQAppModel>>> GetFAQApps()
        {
            var faqapps = await _context.FAQApps.FromSqlRaw("SELECT * FROM FAQApp").ToListAsync();
            // var faqapps = await _context.FAQApps
            //     .ToListAsync();
            if (faqapps != null)    
                return Ok(faqapps);
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FAQAppModel>> GetSingleFAQ(int id)
        {
            List<FAQAppModel> faqapps = await _context.FAQApps.FromSqlRaw("SELECT * FROM FAQApp").ToListAsync();
            var faq = faqapps.FirstOrDefault(h => h.QuestionId == id);
            if(faq == null)
            {
                return NotFound("Sorry no faq here");
            }
            return Ok(faq);
        }

        [HttpPost]
        public async Task<ActionResult<FAQAppModel>> CreateFAQ(FAQAppModel faq)
        {
            await _context.FAQApps.AddAsync(faq);
            await _context.SaveChangesAsync();
            return Ok(faq);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FAQAppModel>> UpdateFAQ(FAQAppModel faq, int id)
        {
            var oldfaq = await _context.FAQApps
                .FirstOrDefaultAsync(h => h.QuestionId == id);
            if (oldfaq == null)
            {
                return NotFound("Sorry no faq here");
            }
            oldfaq.QuestionId = faq.QuestionId;
            oldfaq.QuestionType = faq.QuestionType;
            oldfaq.Question = faq.Question;
            oldfaq.Answers = faq.Answers;
            await _context.SaveChangesAsync();
            return Ok(faq);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFAQ(int id)
        {
            var faq = await _context.FAQApps
                .FirstOrDefaultAsync(h => h.QuestionId == id);
            if (faq == null)
            {
                return NotFound("Sorry no faq here");
            }
            _context.FAQApps.Remove(faq);
            _context.SaveChanges();
            return Ok();
        }
    }
}
