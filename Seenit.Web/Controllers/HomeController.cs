using Seenit.Data.Models;
using Seenit.Data.Services;
using Seenit.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seenit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostData postData;
        private readonly ICommentData commentData;

        public HomeController(IPostData postData, ICommentData commentData)
        {
            this.postData = postData;
            this.commentData = commentData;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = postData.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Seenit is for posting and commenting!";

            return View();
        }

        [HttpGet]
        public ActionResult PostDetails(int id)
        {
            var post = postData.Get(id);
            if (post == null)
            {
                return View("NotFound");
            }

            var model = new PostViewModel { Post = post, Comments = commentData.GetAllForPost(post.ID) };
            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostTime = DateTime.Now;
                postData.Add(post);
                return RedirectToAction("PostDetails", new { id = post.ID });
            }

            return View();
        }

        [HttpGet]
        public ActionResult NewComment(int postId)
        {
            var model = new Comment { PostID = postId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.PostTime = DateTime.Now;
                commentData.Add(comment, comment.PostID);
                return RedirectToAction("PostDetails", new { id = comment.PostID });
            }

            return View();
        }


    }
}