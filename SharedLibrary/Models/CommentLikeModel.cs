using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class CommentLikeModel
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public virtual CommentModel Comment { get; set; }
        public virtual UserModel User { get; set; }
    }
}
