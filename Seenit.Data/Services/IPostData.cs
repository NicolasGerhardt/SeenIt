using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public interface IPostData
    {
        IEnumerable<Post> GetAll();
        Post Get(int ID);
        void Add(Post post);
    }
}
