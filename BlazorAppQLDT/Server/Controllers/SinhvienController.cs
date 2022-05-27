using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using BlazorAppQLDT.Server.Data;

namespace BlazorAppQLDT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment env;
        private readonly ILogger<SinhvienController> logger;
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
            var resutl = await _context.Sinhviens.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return Ok(resutl);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<SinhvienModel>>> SearchNull()
        {
            var resutl = _context.Sinhviens.ToList();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienModel>>> CreateSinhVien(SinhvienModel student)
        {
            _context.Sinhviens.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
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
        public async Task<ActionResult<List<SinhvienModel>>> UpdateSinhvien(SinhvienModel student, int id)
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
