using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppQLDT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienCD15Controller : ControllerBase
    {
        private readonly DataContext _context;
        public SinhvienCD15Controller(DataContext context)
        {
            _context = context;
        }
        //get Key
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
        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<SinhvienModel>>> SearchSinhvien(string name)
        {
            var resutl = await _context.DataCD15.Where(s => s.HoTen.ToLower().Contains(name.ToLower())).ToListAsync();
            return Ok(resutl);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<SinhvienModel>>> SearchNull()
        {
            var resutl = _context.DataCD15.ToList();
            return Ok(resutl);
        }
        [HttpGet]
        public async Task<ActionResult<List<SinhvienCD15Model>>> GetSinhvienDetail()
        {
            
            var resutl = await _context.DataCD15.ToListAsync();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienCD15Model>>> CreateSinhVien(SinhvienCD15Model student)
        {
            _context.DataCD15.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinhvienCD15Model>> GetSingleHero(int id)
        {
            var student = await _context.DataCD15.FirstOrDefaultAsync(h => h.Id == id);
            if (student == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SinhvienCD15Model>>> UpdateSuperHero(SinhvienCD15Model student, int id)
        {
            var dbStudent = await _context.DataCD15
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no hero for you. :/");
            dbStudent.Tinh = dbStudent.Tinh;
            dbStudent.HoTen = student.HoTen;
            dbStudent.NgaySinh = student.NgaySinh;
            dbStudent.ThangSinh = student.ThangSinh;
            dbStudent.NamSinh = student.NamSinh;
            dbStudent.IdNumber = student.IdNumber;
            dbStudent.Truong = student.Truong;
            dbStudent.Lop = student.Lop;
            dbStudent.SoDienThoai = student.SoDienThoai;
            dbStudent.Status = student.Status;
            dbStudent.UpdatedDateTime = student.UpdatedDateTime;
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SinhvienCD15Model>>> DeleteSinhvien(int id)
        {
            var dbStudent = await _context.DataCD15.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.DataCD15.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
    }
}
