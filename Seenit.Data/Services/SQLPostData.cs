using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public class SQLPostData : IPostData
    {
        private readonly SeenitDBContext db;
        public SQLPostData(SeenitDBContext db)
        {
            this.db = db;
        }
        public void Add(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public Post Get(int id)
        {
            return db.Posts.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return from p in db.Posts
                   orderby p.PostTime descending
                   select p;
        }
    }
}
