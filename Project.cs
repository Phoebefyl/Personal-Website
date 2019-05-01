using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class Project
    {
        [Required]
        [Key]
        public int projectID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string content { get; set; }

        public string url { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Category category { get; set; }

        [Required]
        [Display(Name = "Create Date")]
        public DateTime createTime{ get; set; }

        [Display(Name = "Update Date")]
        public DateTime updateTime { get; set; }

        [Required]
        [Display(Name = "Author")]
        public User author { get; set; }



        public IEnumerable<Comment> comments { get; set; }
    }
}
