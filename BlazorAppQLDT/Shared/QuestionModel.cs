using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppQLDT.Shared
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public AnswersModel? FQA { get; set; }
        public int FQAId { get; set; }
        public string Question { get; set; }
        public int? QuestionType { get; set; } 
        
               
    }
}
