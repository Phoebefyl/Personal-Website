using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class User
    {
        [Required]
        [Key]
        public int userID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Author Name")]
        public string userName { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        public string avatarURL { get; set; }
    }
}
