using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppQLDT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienController : ControllerBase
    {
        private readonly DataContext _context;
        public SinhvienController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SinhvienModel>>> GetSinhvienDetail()
        {
            var resutl = _context.Sinhviens.ToList();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienModel>>> CreateSinhVien(SinhvienModel student)
        {
            _context.Sinhviens.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhvienModel>> GetSingleHero(int id)
        {
            var student = await _context.Sinhviens.FirstOrDefaultAsync(h => h.Id == id);
            if (student == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SinhvienModel>>> UpdateSuperHero(SinhvienModel student, int id)
        {
            var dbStudent = await _context.Sinhviens
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbStudent.Name = student.Name;
            dbStudent.Ngaysinh = student.Ngaysinh;
            dbStudent.Nganh = student.Nganh;
            dbStudent.Hedaotao = student.Hedaotao;
            dbStudent.Ketqua = student.Ketqua;
            dbStudent.Hinhthuc = student.Hinhthuc;
            dbStudent.Tinhtrang = student.Tinhtrang;
            dbStudent.Mail = student.Mail;
            dbStudent.check_mail = student.check_mail;
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SinhvienModel>>> DeleteSinhvien(int id)
        {
            var dbStudent = await _context.Sinhviens.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.Sinhviens.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
    }
}
