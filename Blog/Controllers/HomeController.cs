using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext _context;

        public HomeController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ViewBlogPostList()
        {

            ViewModelPosts model = new ViewModelPosts();
            model.categories= _context.Category.ToList();
            model.blogPosts = _context.BlogPost.OrderByDescending(n => n.Date).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewBlogPostList(ViewModelPosts values)
        {
            ViewModelPosts model = new ViewModelPosts();
            if(values.SearchValue == null)
            {
              model.blogPosts = _context.BlogPost.Where
             (n=> n.CategoryId == values.currentPost.CategoryId).OrderByDescending(n => n.Date).ToList();
            }
            else
            {
                model.blogPosts = _context.BlogPost.Where(p => p.Heading.Contains(values.SearchValue)
               && p.Category.CategoryId == values.currentPost.CategoryId).OrderByDescending(n => n.Date).ToList();
            }

            model.categories = _context.Category.ToList();
            return View(model);
        }

        public IActionResult ViewBlogPost(int id)
        {
            var mod = _context.BlogPost.SingleOrDefault(p => p.PostId == id);
            return View(mod);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewModelPosts model = new ViewModelPosts();
            model.categories = _context.Category.ToList();
            return View(model);
        }

  
            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewModelPosts posts)
        {
             
          if(ModelState.IsValid)
            {
                posts.currentPost.Date = DateTime.Now;
                _context.BlogPost.Add(posts.currentPost);
                _context.SaveChanges();
                return RedirectToAction("ViewBlogPostList");
            }
          else
            {
                posts.categories = _context.Category.ToList();
                return View(posts);
            }
        }


        public IActionResult Index()
        {

            var posted = _context.BlogPost.ToList();

            return View(posted);
        }

    }
}

