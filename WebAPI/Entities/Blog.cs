using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Blog
    {
        public Blog()
        {
            BlogLikes = new HashSet<BlogLike>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        public byte[] Image { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Blogs")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(BlogLike.Blog))]
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
        [InverseProperty(nameof(Comment.Blog))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
