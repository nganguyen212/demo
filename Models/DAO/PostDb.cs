using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PostDb
    {
        DtbContext context = null;
        public PostDb()
        {
            context = new DtbContext();
        }
        public IEnumerable<post> GetPosts()
        {
            var result = context.posts.OrderByDescending(x => x.title).ToList();
            return result;
        }
        public void Insert<T>(T model) where T : class
        {
            using (var ct = new DtbContext())
            {
               ct.Set<T>().Add(model);
               ct.SaveChanges();

            }
        }
        public post GetPostById(int id)
        {
            return context.posts.Where(x => x.id == id).FirstOrDefault();
        }
        public bool UpdatePost(post po)
        {
            try
            {

                var p = context.posts.Find(po.id);
                p.title=po.title;
                p.description = po.description;
                p.category = po.category;
                p.publish_state = false;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteById(int id)
        {
            var result = context.posts.Find(id);
            context.posts.Remove(result);
            context.SaveChanges();
            return true;

        }
    }
}
