using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Category
    {
        public Category()
        {
            BlogPost = new HashSet<BlogPost>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BlogPost> BlogPost { get; set; }
    }
}
