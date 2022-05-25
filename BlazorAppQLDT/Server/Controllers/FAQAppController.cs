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
        public async Task<ActionResult<List<FAQApp>>> GetFAQApps()
        {
            var faqapps = _context.FAQApps.FromSqlRaw("SELECT * FROM FAQApp Order By QuestionId").ToList();
            // var faqapps = await _context.FAQApps
            //     .ToListAsync();
            if (faqapps != null)
                return Ok(faqapps);
            else
            {
                return NotFound();
            }
        }
    }
}
