using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int BlogCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<BlogLikeModel> BlogLikes { get; set; }
        public virtual ICollection<BlogModel> Blogs { get; set; }
        public virtual ICollection<CommentLikeModel> CommentLikes { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
    }
}
