using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class User
    {
        public User()
        {
            BlogLikes = new HashSet<BlogLike>();
            Blogs = new HashSet<Blog>();
            CommentLikes = new HashSet<CommentLike>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public int BlogCount { get; set; }
        public int CommentCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [InverseProperty(nameof(BlogLike.User))]
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
        [InverseProperty(nameof(Blog.User))]
        public virtual ICollection<Blog> Blogs { get; set; }
        [InverseProperty(nameof(CommentLike.User))]
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
        [InverseProperty(nameof(Comment.User))]
        public virtual ICollection<Comment> Comments { get; set; }

        public void CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512(PasswordSalt);
            var ch = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] != PasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
