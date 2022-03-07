using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class BlogLike
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(BlogId))]
        [InverseProperty("BlogLikes")]
        public virtual Blog Blog { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("BlogLikes")]
        public virtual User User { get; set; }
    }
}
