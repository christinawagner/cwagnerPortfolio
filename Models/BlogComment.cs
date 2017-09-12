using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cwagnerPortfolio.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int BlogId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string UpdatedReason { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}