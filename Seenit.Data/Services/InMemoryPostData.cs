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
                new Post { ID = 0, Title = "First!!", Username = "Nic", Text = "This is the first post in the In Memory Data", PostTime = DateTime.Now},
                new Post { ID = 1, Title = "Test Post 1", Username = "Nic", Text = "This is Test Data!! 1", PostTime = DateTime.Now},
                new Post { ID = 2, Title = "Test Post 2", Username = "Nic", Text = "This is Test Data!! 2", PostTime = DateTime.Now}
            };
        }

        public void Add(Post post)
        {
            Posts.Add(post);
            post.ID = Posts.Max(p => p.ID) + 1;
        }

        public Post Get(int id)
        {
            return Posts.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return Posts.OrderByDescending(p => p.PostTime);
        }
    }
}
