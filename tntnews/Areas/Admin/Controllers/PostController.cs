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
        // Andmin/post/CreatePost
        [HttpGet]
        public ActionResult CreatePost()
        {
            SetViewBag();
            return View();
        }
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult CreatePost(post model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PostDb();
                var po = new post();

                po.title = model.title;
                po.category = model.category;
                po.description = model.description;
                po.created_at = DateTime.Now;
                po.publish_state = false;
                po.img = model.img;

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
        [HttpGet]
        public ActionResult UpdatePost(int id)
        {
            SetViewBag();
            var dao = new PostDb().GetPostById(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult UpdatePost(post model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PostDb();
                var result = dao.UpdatePost(model);
                if (result ==true) {

                    return RedirectToAction("Index","Post");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var dao = new PostDb().DeleteById(id);
            if (dao)
            {
                return RedirectToAction("Index", "Post");
            }
            return View();

        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CateDb();
            ViewBag.Category = new SelectList(dao.ListCategory(), "id", "name",selectedId);
        }

    }
}