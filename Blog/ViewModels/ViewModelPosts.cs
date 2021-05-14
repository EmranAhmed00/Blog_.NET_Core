using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ViewModelPosts
    {
        public List<BlogPost> blogPosts { get; set; }
        public List<Category> categories { get; set; }
        public BlogPost  currentPost { get; set; }
        public string SearchValue { get; set; }


        public ViewModelPosts()
        {
            blogPosts = new List<BlogPost>();
            categories = new List<Category>();
            currentPost = new BlogPost();
           
        }

    }
}


