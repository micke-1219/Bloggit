using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int LikeCount { get; set; }
        public string UserName { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string Reply { get; set; }
        public virtual BlogModel Blog { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<CommentLikeModel> CommentLikes { get; set; }
    }
}
