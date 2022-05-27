using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppQLDT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienCD18Controller : ControllerBase
    {
        private readonly DataContext _context;
        public SinhvienCD18Controller(DataContext context)
        {
            _context = context;
        }
        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<SinhvienCD18Model>>> SearchSinhvien(string name)
        {
            var resutl = await _context.SinhvienCD18.Where(s => s.Hoten.ToLower().Contains(name.ToLower())).ToListAsync();
            return Ok(resutl);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<SinhvienCD18Model>>> SearchNull()
        {
            var resutl = _context.SinhvienCD18.ToList();
            return Ok(resutl);
        }
        [HttpGet("applicationconfig")]
        public async Task<ActionResult<List<ApplicationConfig>>> GetKey()
        {
            var resutl = _context.ApplicationConfigs.FirstOrDefault(a => a.Id >= 1);
            if (resutl.LastUpdatedDateTime.AddMinutes(-50) > DateTime.Now)
            {
                return null;
            }
            return Ok(resutl);
        }
        [HttpGet]
        public async Task<ActionResult<List<SinhvienCD18Model>>> GetSinhvienDetail()
        {
            var resutl = _context.SinhvienCD18.ToList();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienCD18Model>>> CreateSinhVien(SinhvienCD18Model student)
        {
            _context.SinhvienCD18.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinhvienCD18Model>> GetSingleHero(int id)
        {
            var student = await _context.SinhvienCD18.FirstOrDefaultAsync(h => h.Id == id);
            if (student == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SinhvienCD18Model>>> UpdateSuperHero(SinhvienCD18Model student, int id)
        {
            var dbStudent = await _context.SinhvienCD18
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no hero for you. :/");
            dbStudent.Tinh = student.Tinh;
            dbStudent.Hoten = student.Hoten;
            dbStudent.Ngaysinh = student.Ngaysinh;
            dbStudent.Thangsinh = student.Thangsinh;
            dbStudent.Namsinh = student.Namsinh;
            dbStudent.IdNumber = student.IdNumber;
            dbStudent.Truong = student.Truong;
            dbStudent.Lop = student.Lop;
            dbStudent.Sodienthoai = student.Sodienthoai;
            dbStudent.Status = student.Status;
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SinhvienCD18Model>>> DeleteSinhvien(int id)
        {
            var dbStudent = await _context.SinhvienCD18.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.SinhvienCD18.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
    }
}
