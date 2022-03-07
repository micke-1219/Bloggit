using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class BlogLikeModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual BlogModel Blog { get; set; }
        public virtual UserModel User { get; set; }
    }
}
