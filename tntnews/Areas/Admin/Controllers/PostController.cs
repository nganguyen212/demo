using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tntnews.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            var post = new PostDb();
            var model = post.GetPosts();
            return View(model);
           
        }
        public ActionResult CreatePost()
        {
            return View();
        }
        public ActionResult HienThiPost()
        {
            var post = new PostDb();
            var model = post.GetPosts();
            return View(model);
        }
        public ActionResult CreatePost(post model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PostDb();
                var po = new post();

                po.title = model.title;

                if (po != null)
                {
                    dao.Insert<post>(po);
                    return RedirectToAction("index");

                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm không thành công");
            }
            return View();
        }
        public ActionResult UpdatePost()
        {


            return View();
        }
        public ActionResult UpdatePost(post model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PostDb();

            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View();
        }

    }
}