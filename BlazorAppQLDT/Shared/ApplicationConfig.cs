using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppQLDT.Shared
{
    public class ApplicationConfig
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string AppId { get; set; }
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string AccessToken { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
    }
}
