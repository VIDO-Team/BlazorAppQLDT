using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BlazorAppQLDT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadExcelController : ControllerBase
    {
        private readonly DataContext _context;
        DataTable dataTable = new DataTable();
        SinhvienModel objStudent = new SinhvienModel();
        [HttpGet]
        public async Task<ActionResult<List<SinhvienModel>>> GetExcelDetail()
        {
            var resutl = _context.Sinhviens.ToList();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienModel>>> CreateExcelDetail(SinhvienModel student)
        {
            _context.Sinhviens.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await GetExcelDetail());
        }

    }
}
