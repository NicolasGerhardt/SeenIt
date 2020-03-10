using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public interface ICommentData
    {
        IEnumerable<Comment> GetAllForPost(int postID);
        void Add(Comment comment, int postID);
    }
}
