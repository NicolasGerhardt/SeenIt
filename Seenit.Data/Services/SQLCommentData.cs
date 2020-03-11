using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public class SQLCommentData : ICommentData
    {
        private readonly SeenitDBContext db;

        public SQLCommentData(SeenitDBContext db)
        {
            this.db = db;
        }

        public void Add(Comment comment, int postID)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public IEnumerable<Comment> GetAllForPost(int postID)
        {
            return db.Comments.Where(c => c.PostID == postID)
                              .OrderBy(c => c.PostTime);

        }
    }
}
