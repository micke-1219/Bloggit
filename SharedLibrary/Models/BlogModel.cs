using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Title can not contain more than 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public byte[] Image { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<BlogLikeModel> BlogLikes { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
    }
}
