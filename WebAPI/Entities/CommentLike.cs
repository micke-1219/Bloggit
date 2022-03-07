using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class CommentLike
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(CommentId))]
        [InverseProperty("CommentLikes")]
        public virtual Comment Comment { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("CommentLikes")]
        public virtual User User { get; set; }
    }
}
