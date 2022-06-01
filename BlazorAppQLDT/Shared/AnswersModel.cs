using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppQLDT.Shared
{
    public class AnswersModel
    {
        public int Id { get; set; }
        public string? Answers { get; set; }
        public byte? STT { get; set; }
        public string? Type { get; set; }
    }
}
