using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StuxGeek.Models
{
    public class Post
    {

        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Content { get; set; }

        [Required] //Meerdere categories
        public string Category { get; set; }
        
        public string Author { get; set; }

        [Required] //meerdere Tags
        public string Tag { get; set; }

        
        public DateTime PostDate { get; set; }
    }
}