using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorAppQLDT.Shared
{
    public class SinhvienCD18Model
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tinh { get; set; } = String.Empty;
        [Required]
        public string Hoten { get; set; } = String.Empty;
        [Required]
        public int? Ngaysinh { get; set; }
        [Required]
        public int? Thangsinh { get; set; }
        [Required]
        public int? Namsinh { get; set; }
        [Required]
        public string IdNumber { get; set; } = String.Empty;
        [Required]
        public string Truong { get; set; } = String.Empty;
        [Required]
        public string Lop { get; set; } = String.Empty;
        [Required]
        public string Sodienthoai { get; set; } = String.Empty;
        [Required]
        public int? Status { get; set; }
        
    }
}