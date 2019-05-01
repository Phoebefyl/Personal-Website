using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class Comment
    {
        [Required]
        [Key]
        public int commentID { get; set; }

        [Required]
        [StringLength(500)]
        public string content { get; set; }

        [Required]
        public DateTime postTime{ get; set; }

        [Required]
        public bool status { get; set; } //true: allowed to show; false: not allowed;.

        [Required]
        public User author { get; set; }

        public Project project { get; set; }

        public Interest interest { get; set; }

        public Career career { get; set; }

    }
}
