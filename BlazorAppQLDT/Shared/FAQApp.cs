using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppQLDT.Shared
{
    public class FAQApp
    {
        public int Id {get; set;}
        public int QuestionId { get; set; }
        public int QuestionType { get; set; } 
        public string Question { get; set; }
        public string Answers { get; set; }
    }
}
