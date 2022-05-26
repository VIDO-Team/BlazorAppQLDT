using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorAppQLDT.Shared
{
    public class SinhvienCD15Model
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tinh { get; set; } = String.Empty;
        [Required]
        public string HoTen { get; set; } = String.Empty;
        [Required]
        public int? NgaySinh { get; set; }
        [Required]
        public int? ThangSinh { get; set; }
        [Required]
        public int? NamSinh { get; set; }
        [Required]
        public string IdNumber { get; set; } = String.Empty;
        [Required]
        public string Truong { get; set; } = String.Empty;
        [Required]
        public string Lop { get; set; } = String.Empty;
        [Required]
        public string SoDienThoai { get; set; } = String.Empty;
        [Required]
        public int? Status { get; set; }
        [Required]
        public DateTime? UpdatedDateTime { get; set; }
        [Required]
        public string ResponseStatus { get; set; } = String.Empty;
    }
}
