using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            CommentLikes = new HashSet<CommentLike>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        public int LikeCount { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string Reply { get; set; }

        [ForeignKey(nameof(BlogId))]
        [InverseProperty("Comments")]
        public virtual Blog Blog { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Comments")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(CommentLike.Comment))]
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
    }
}
