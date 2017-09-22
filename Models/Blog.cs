using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cwagnerPortfolio.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [AllowHtml]
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        [Display(Name = "Image")]
        public string MediaUrl { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<BlogComment>Comments { get; set; }

        public Blog()
        {
            Comments = new HashSet<BlogComment>();
        }
    }
}