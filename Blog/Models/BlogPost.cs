using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public partial class BlogPost
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage =" Must be fill")]
        [StringLength(50, ErrorMessage = "Heading Can be maximum 50 letters")]
        public string Heading { get; set; }
        [Required(ErrorMessage = "Must be fill")]
        [StringLength(2000, ErrorMessage = "Text Can be maximum 2000 letters")]
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public virtual Category Category { get; set; }
    }
}
