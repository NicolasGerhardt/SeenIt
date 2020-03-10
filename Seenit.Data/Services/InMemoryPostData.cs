using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public class InMemoryPostData : IPostData
    {
        List<Post> Posts;

        public InMemoryPostData()
        {
            Posts = new List<Post>
            {
                new Post { ID = 0, Title = "First!!", Text = "This is the first post in the In Memory Data", PostTime = DateTime.Now},
                new Post { ID = 1, Title = "Second!", Text = "This is the Second post in the In Memory Data", PostTime = DateTime.Now},
                new Post { ID = 2, Title = "Third", Text = "This is what it feels like to be a loser\n:-(", PostTime = DateTime.Now}
            };
        }

        public Post Get(int id)
        {
            return Posts.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return Posts.OrderBy(p => p.PostTime);
        }
    }
}
