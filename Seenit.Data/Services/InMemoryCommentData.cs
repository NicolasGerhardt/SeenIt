using Seenit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seenit.Data.Services
{
    public class InMemoryCommentData : ICommentData
    {

        List<Comment> comments;

        public InMemoryCommentData()
        {
            comments = new List<Comment> 
            { 
                new Comment { ID = 0, PostID = 0, Username = "Nic", Text = "Lol In Memorty Comment First!", PostTime = DateTime.Now },
                new Comment { ID = 1, PostID = 0, Username = "Nic", Text = "This is all testData!! 1", PostTime = DateTime.Now },
                new Comment { ID = 2, PostID = 1, Username = "Nic", Text = "This is all testData!! 2", PostTime = DateTime.Now },
                new Comment { ID = 3, PostID = 1, Username = "Nic", Text = "This is all testData!! 3", PostTime = DateTime.Now },
                new Comment { ID = 4, PostID = 2, Username = "Nic", Text = "This is all testData!! 4", PostTime = DateTime.Now },
                new Comment { ID = 5, PostID = 2, Username = "Nic", Text = "This is all testData!! 5", PostTime = DateTime.Now }
            };

        }

        public void Add(Comment comment, int postID)
        {
            comments.Add(comment);
            comment.ID = comments.Max(c => c.ID) + 1;
            comment.PostID = postID;
        }

        public IEnumerable<Comment> GetAllForPost(int postID)
        {
            return comments.FindAll(c => c.PostID == postID).OrderBy(c => c.PostTime);
        }
    }
}
