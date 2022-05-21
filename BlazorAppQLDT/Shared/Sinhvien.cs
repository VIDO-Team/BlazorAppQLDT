using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorAppQLDT.Shared
{
    public class SinhvienModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? Ngaysinh { get; set; }
        [Required]
        public string Nganh { get; set; }
        [Required]
        public string Hedaotao { get; set; }
        [Required]
        public string Ketqua { get; set; }
        [Required]
        public string Hinhthuc { get; set; }
        [Required]
        public string Tinhtrang { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public int? check_mail { get; set; }
    }
}
